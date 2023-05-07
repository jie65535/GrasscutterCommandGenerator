package emu.grasscutter.tools;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.*;
import java.util.function.Function;
import java.util.stream.Collectors;
import java.util.stream.IntStream;
import java.util.stream.LongStream;

import emu.grasscutter.GameConstants;
import emu.grasscutter.Grasscutter;
import emu.grasscutter.command.CommandHandler;
import emu.grasscutter.command.CommandMap;
import emu.grasscutter.data.GameData;
import emu.grasscutter.data.ResourceLoader;
import emu.grasscutter.data.excels.AchievementData;
import emu.grasscutter.data.excels.AvatarData;
import emu.grasscutter.data.excels.ItemData;
import emu.grasscutter.game.inventory.ItemType;
import emu.grasscutter.game.inventory.MaterialType;
import emu.grasscutter.game.props.MonsterType;
import emu.grasscutter.utils.Language;
import emu.grasscutter.utils.Language.TextStrings;
import emu.grasscutter.utils.SparseSet;
import it.unimi.dsi.fastutil.ints.Int2IntRBTreeMap;
import it.unimi.dsi.fastutil.ints.Int2ObjectRBTreeMap;
import lombok.val;

import static emu.grasscutter.config.Configuration.*;
import static emu.grasscutter.utils.FileUtils.getResourcePath;
import static emu.grasscutter.utils.Language.getTextMapKey;

public final class Tools {
    public static void createGmHandbooks() throws Exception {
        val languages = Language.TextStrings.getLanguages();

        ResourceLoader.loadAll();

        SparseSet illegalWeaponIds = new SparseSet("""
        10000-10008, 11411, 11506-11508, 12505, 12506, 12508, 12509,
        13503, 13506, 14411, 14503, 14505, 14508, 15504-15506
        """);

        SparseSet illegalRelicIds = new SparseSet("""
        20001, 23300-23340, 23383-23385, 78310-78554, 99310-99554
        """);

        SparseSet illegalItemIds = new SparseSet("""
        3004-3022, 100086, 100087, 100100-101000, 101106-101110, 101306, 101500-104000,
        105001, 105004, 106000-107000, 107011, 108000, 109000-110000,
        115000-130000, 200200-200899, 220050, 220054
        """);


        val mainQuestTitles = new Int2IntRBTreeMap(GameData.getMainQuestDataMap().int2ObjectEntrySet().stream().collect(Collectors.toMap(e -> (int) e.getIntKey(), e -> (int) e.getValue().getTitleTextMapHash())));
        // val questDescs = new Int2IntRBTreeMap(GameData.getQuestDataMap().int2ObjectEntrySet().stream().collect(Collectors.toMap(e -> (int) e.getIntKey(), e -> (int) e.getValue().getDescTextMapHash())));

        val avatarDataMap = new Int2ObjectRBTreeMap<>(GameData.getAvatarDataMap());
        val itemDataMap = new Int2ObjectRBTreeMap<>(GameData.getItemDataMap());
        val monsterDataMap = new Int2ObjectRBTreeMap<>(GameData.getMonsterDataMap());
        val sceneDataMap = new Int2ObjectRBTreeMap<>(GameData.getSceneDataMap());
        val questDataMap = new Int2ObjectRBTreeMap<>(GameData.getQuestDataMap());
        val achievementDataMap = new Int2ObjectRBTreeMap<>(GameData.getAchievementDataMap());

        // Create builders and helper functions
        val handbookBuilders = IntStream.range(0, TextStrings.NUM_LANGUAGES).mapToObj(i -> new StringBuilder()).toList();
        var h = new Object() {
            void newLine(String line) {
                handbookBuilders.forEach(b -> b.append(line + "\n"));
            }
            void newSection(String title) {
                newLine("\n\n// " + title);
            }
            void newTranslatedLine(String template, TextStrings... textstrings) {
                for (int i = 0; i < TextStrings.NUM_LANGUAGES; i++) {
                    String s = template;
                    for (int j = 0; j < textstrings.length; j++)
                        s = s.replace("{"+j+"}", textstrings[j].strings[i]);
                    handbookBuilders.get(i).append(s + "\n");
                }
            }
            void newTranslatedLine(String template, long... hashes) {
                newTranslatedLine(template, LongStream.of(hashes).mapToObj(hash -> getTextMapKey(hash)).toArray(TextStrings[]::new));
            }
        };
        Grasscutter.getLogger().debug("Generating...");

        // Preamble
        h.newLine("// Grasscutter " + GameConstants.VERSION + " GM Handbook");
        h.newLine("// Created " + DateTimeFormatter.ofPattern("yyyy/MM/dd HH:mm:ss").format(LocalDateTime.now()));

        // Commands
        Grasscutter.getLogger().debug("Commands generating...");
        h.newSection("Commands");
        final List<CommandHandler> cmdList = CommandMap.getInstance().getHandlersAsList();
        final String padCmdLabel = "%s:";
        for (CommandHandler cmd : cmdList) {
            final String label = padCmdLabel.formatted(cmd.getLabel());
            final String descKey = cmd.getDescriptionKey();
            for (int i = 0; i < TextStrings.NUM_LANGUAGES; i++) {
                String desc = languages.get(i).get(descKey).replace("\n", "\n\t");
                handbookBuilders.get(i).append(label + desc + "\n");
            }
        }
        // Avatars
        Grasscutter.getLogger().debug("Avatars generating...");
        h.newSection("Avatars");
        for (val data : avatarDataMap.values()) {
            if (data.getId() >= 10000002 && data.getId() < 11000000)
                h.newTranslatedLine("%d:{0}".formatted(data.getId()), data.getNameTextMapHash());
        }
//        avatarDataMap.forEach((id, data) -> h.newTranslatedLine("%d:".formatted(id) + "{0}", data.getNameTextMapHash()));
        // Items
        Grasscutter.getLogger().debug("Items generating...");
        h.newSection("Items");
        Map<ItemType, List<ItemData>> items = new HashMap<>();
        for (val type : ItemType.values()) {
            items.put(type, new ArrayList<>());
        }
        for (val item : itemDataMap.values()) {
            if (!illegalItemIds.contains(item.getId()))
                items.get(item.getItemType()).add(item);
        }
        items.get(ItemType.ITEM_WEAPON).removeIf(data -> illegalWeaponIds.contains(data.getId()));
        items.get(ItemType.ITEM_RELIQUARY).removeIf(data -> illegalRelicIds.contains(data.getId()));
        for (val kv : items.entrySet()
            .stream()
            .filter(e -> e.getValue().size() > 0)
            .sorted(Comparator.comparing(e -> e.getValue().get(0).getId()))
            .toList()) {

            if (kv.getValue().size() == 0)
                continue;
            Grasscutter.getLogger().debug(kv.getKey().name() + " generating...");
            h.newSection(kv.getKey().name());
            if (kv.getKey() == ItemType.ITEM_MATERIAL) {
                Map<MaterialType, List<ItemData>> materials = new HashMap<>();
                for (val type : MaterialType.values()) {
                    materials.put(type, new ArrayList<>());
                }
                for (val item : kv.getValue()) {
                    materials.get(item.getMaterialType()).add(item);
                }
                for (val mkv : materials.entrySet()
                    .stream()
                    .filter(e -> e.getValue().size() > 0)
                    .sorted(Comparator.comparing(e -> e.getValue()
                        .stream()
                        .mapToInt(ItemData::getId)
                        .average()
                        .orElse(0)))
                    .toList()) {

                    Grasscutter.getLogger().debug(mkv.getKey().name() + " generating...");
                    h.newSection(mkv.getKey().name());
                    if (mkv.getKey() == MaterialType.MATERIAL_BGM) {
                        for (val item : mkv.getValue()) {
                            val bgmName = Optional.ofNullable(item.getItemUse())
                                .map(u -> u.get(0))
                                .map(u -> u.getUseParam())
                                .filter(u -> u.length > 0)
                                .map(u -> Integer.parseInt(u[0]))
                                .map(bgmId -> GameData.getHomeWorldBgmDataMap().get(bgmId))
                                .map(bgm -> bgm.getBgmNameTextMapHash())
                                .map(hash -> getTextMapKey(hash));
                            if (bgmName.isPresent()) {
                                h.newTranslatedLine("%d:{0} - {1}".formatted(item.getId()), getTextMapKey(item.getNameTextMapHash()), bgmName.get());
                                continue;
                            }  // Fall-through
                            h.newTranslatedLine("%d:{0}".formatted(item.getId()), getTextMapKey(item.getNameTextMapHash()));
                        }
                    } else {
                        for (val item : mkv.getValue()) {
                            h.newTranslatedLine("%d:{0}".formatted(item.getId()), getTextMapKey(item.getNameTextMapHash()));
                        }
                    }
                }
            } else {
                for (val item : kv.getValue()) {
                    h.newTranslatedLine("%d:{0}".formatted(item.getId()), getTextMapKey(item.getNameTextMapHash()));
                }
            }
        }

//        h.newSection("WeaponColors");
//        for (val data : items.get(ItemType.ITEM_WEAPON)) {
//            val color = switch (data.getRankLevel()) {
//                case 3 -> "blue";
//                case 4 -> "purple";
//                case 5 -> "yellow";
//                default -> null;
//            };
//            if (color != null) {
//                h.newLine("%d:%s".formatted(data.getId(), color));
//            }
//        }
//
//        h.newSection("AvatarColors");
//        for (val data : avatarDataMap.values()) {
//            if (data.getId() >= 10000002 && data.getId() < 11000000) {
//                String color = switch (data.getQualityType()) {
//                    case "QUALITY_PURPLE" -> "purple";
//                    case "QUALITY_ORANGE" -> "yellow";
//                    case "QUALITY_BLUE" -> "blue";
//                    default -> "";
//                };
//                h.newLine("%d:%s".formatted(data.getId(), color));
//            }
//        }

//        itemDataMap.forEach((id, data) -> {
//            val name = getTextMapKey(data.getNameTextMapHash());
//            switch (data.getMaterialType()) {
//                case MATERIAL_BGM:
//                    val bgmName = Optional.ofNullable(data.getItemUse())
//                        .map(u -> u.get(0))
//                        .map(u -> u.getUseParam())
//                        .filter(u -> u.length > 0)
//                        .map(u -> Integer.parseInt(u[0]))
//                        .map(bgmId -> GameData.getHomeWorldBgmDataMap().get(bgmId))
//                        .map(bgm -> bgm.getBgmNameTextMapHash())
//                        .map(hash -> getTextMapKey(hash));
//                    if (bgmName.isPresent()) {
//                        h.newTranslatedLine("%d:".formatted(id) + "{0} - {1}", name, bgmName.get());
//                        return;
//                    }  // Fall-through
//                default:
//                    h.newTranslatedLine("%d:".formatted(id) + "{0}", name);
//                    return;
//            }
//        });
        // Monsters
        Grasscutter.getLogger().debug("Monsters generating...");
        h.newSection("Monsters");
        val monsterTypes = MonsterType.values();
        for (val type : monsterTypes) {
            h.newSection(type.name());
            for (val kv : monsterDataMap.int2ObjectEntrySet()) {
                if (kv.getValue().getType() == type)
                    h.newTranslatedLine(
                        "%d:".formatted(kv.getIntKey()) + kv.getValue().getMonsterName() + " - {0}",
                        kv.getValue().getNameTextMapHash());
            }
        }

        // Scenes - no translations
        Grasscutter.getLogger().debug("Scenes generating...");
        h.newSection("Scenes");
        sceneDataMap.forEach((id, data) -> h.newLine("%d:".formatted(id) + data.getScriptData()));
        // Quests
        Grasscutter.getLogger().debug("Quests generating...");
        h.newSection("Quests");
        questDataMap.forEach((id, data) -> h.newTranslatedLine(
            "%d:".formatted(id) + "{0} - {1}",
            mainQuestTitles.get(data.getMainId()),
            data.getDescTextMapHash()));

        // Achievements
        Grasscutter.getLogger().debug("Achievements generating...");
        h.newSection("Achievements");
        achievementDataMap.values().stream()
            .filter(AchievementData::isUsed)
            .forEach(data -> h.newTranslatedLine("%d:".formatted(data.getId()) + "{0} - {1}", data.getTitleTextMapHash(), data.getDescTextMapHash()));

        // Write txt files
        for (int i = 0; i < TextStrings.NUM_LANGUAGES; i++) {
            File GMHandbookOutputpath=new File("./GM Handbook");
            GMHandbookOutputpath.mkdir();
            final String fileName = "./GM Handbook/GM Handbook - %s.txt".formatted(TextStrings.ARR_LANGUAGES[i]);
            Grasscutter.getLogger().debug("Generating " + fileName);
            try (PrintWriter writer = new PrintWriter(new OutputStreamWriter(new FileOutputStream(fileName), StandardCharsets.UTF_8), false)) {
                writer.write(handbookBuilders.get(i).toString());
            }
        }
        Grasscutter.getLogger().info("GM Handbooks generated!");
    }

    public static List<String> createGachaMappingJsons() {
        final int NUM_LANGUAGES = Language.TextStrings.NUM_LANGUAGES;
        final Language.TextStrings CHARACTER = Language.getTextMapKey(4233146695L);  // "Character" in EN
        final Language.TextStrings WEAPON = Language.getTextMapKey(4231343903L);  // "Weapon" in EN
        final Language.TextStrings STANDARD_WISH = Language.getTextMapKey(332935371L);  // "Standard Wish" in EN
        final Language.TextStrings CHARACTER_EVENT_WISH = Language.getTextMapKey(2272170627L);  // "Character Event Wish" in EN
        final Language.TextStrings CHARACTER_EVENT_WISH_2 = Language.getTextMapKey(3352513147L);  // "Character Event Wish-2" in EN
        final Language.TextStrings WEAPON_EVENT_WISH = Language.getTextMapKey(2864268523L);  // "Weapon Event Wish" in EN
        final List<StringBuilder> sbs = new ArrayList<>(NUM_LANGUAGES);
        for (int langIdx = 0; langIdx < NUM_LANGUAGES; langIdx++)
            sbs.add(new StringBuilder("{\n"));  // Web requests should never need Windows line endings

        // Avatars
        GameData.getAvatarDataMap().keySet().intStream().sorted().forEach(id -> {
            AvatarData data = GameData.getAvatarDataMap().get(id);
            int avatarID = data.getId();
            if (avatarID >= 11000000) { // skip test avatar
                return;
            }
            String color = switch (data.getQualityType()) {
                case "QUALITY_PURPLE" -> "purple";
                case "QUALITY_ORANGE" -> "yellow";
                case "QUALITY_BLUE" -> "blue";
                default -> "";
            };
            Language.TextStrings avatarName = Language.getTextMapKey(data.getNameTextMapHash());
            for (int langIdx = 0; langIdx < NUM_LANGUAGES; langIdx++) {
                sbs.get(langIdx)
                    .append("\t\"")
                    .append(avatarID % 1000 + 1000)
                    .append("\": [\"")
                    .append(avatarName.get(langIdx))
                    .append(" (")
                    .append(CHARACTER.get(langIdx))
                    .append(")\", \"")
                    .append(color)
                    .append("\"],\n");
            }
        });

        // Weapons
        GameData.getItemDataMap().keySet().intStream().sorted().forEach(id -> {
            ItemData data = GameData.getItemDataMap().get(id);
            if (data.getId() <= 11101 || data.getId() >= 20000) {
                return; //skip non weapon items
            }
            String color = switch (data.getRankLevel()) {
                case 3 -> "blue";
                case 4 -> "purple";
                case 5 -> "yellow";
                default -> null;
            };
            if (color == null) return;  // skip unnecessary entries
            Language.TextStrings weaponName = Language.getTextMapKey(data.getNameTextMapHash());
            for (int langIdx = 0; langIdx < NUM_LANGUAGES; langIdx++) {
                sbs.get(langIdx)
                    .append("\t\"")
                    .append(data.getId())
                    .append("\": [\"")
                    .append(weaponName.get(langIdx).replaceAll("\"", "\\\\\""))
                    .append(" (")
                    .append(WEAPON.get(langIdx))
                    .append(")\", \"")
                    .append(color)
                    .append("\"],\n");
            }
        });

        for (int langIdx = 0; langIdx < NUM_LANGUAGES; langIdx++) {
            sbs.get(langIdx)
                .append("\t\"200\": \"")
                .append(STANDARD_WISH.get(langIdx))
                .append("\",\n\t\"301\": \"")
                .append(CHARACTER_EVENT_WISH.get(langIdx))
                .append("\",\n\t\"400\": \"")
                .append(CHARACTER_EVENT_WISH_2.get(langIdx))
                .append("\",\n\t\"302\": \"")
                .append(WEAPON_EVENT_WISH.get(langIdx))
                .append("\"\n}");
        }
        return sbs.stream().map(StringBuilder::toString).toList();
    }

    public static void createGachaMappings(Path location) throws IOException {
        ResourceLoader.loadResources();
        List<String> jsons = createGachaMappingJsons();
        var usedLocales = new HashSet<String>();
        StringBuilder sb = new StringBuilder("mappings = {\n");
        for (int i = 0; i < Language.TextStrings.NUM_LANGUAGES; i++) {
            String locale = Language.TextStrings.ARR_GC_LANGUAGES[i].toLowerCase();  // TODO: change the templates to not use lowercased locale codes
            if (usedLocales.add(locale)) {  // Some locales fallback to en-us, we don't want to redefine en-us with vietnamese strings
                sb.append("\t\"%s\": ".formatted(locale));
                sb.append(jsons.get(i).replace("\n", "\n\t") + ",\n");
            }
        }
        sb.setLength(sb.length() - 2);  // Delete trailing ",\n"
        sb.append("\n}");

        Files.createDirectories(location.getParent());
        Files.writeString(location, sb);
        Grasscutter.getLogger().info("Mappings generated to " + location);
    }

    public static List<String> getAvailableLanguage() {
        List<String> availableLangList = new ArrayList<>();
        try {
            Files.newDirectoryStream(getResourcePath("TextMap"), "TextMap*.json").forEach(path -> {
                availableLangList.add(path.getFileName().toString().replace("TextMap", "").replace(".json", "").toLowerCase());
            });
        } catch (IOException e) {
            Grasscutter.getLogger().error("Failed to get available languages:", e);
        }
        return availableLangList;
    }

    @Deprecated(forRemoval = true, since = "1.2.3")
    public static String getLanguageOption() {
        List<String> availableLangList = getAvailableLanguage();

        // Use system out for better format
        if (availableLangList.size() == 1) {
            return availableLangList.get(0).toUpperCase();
        }
        StringBuilder stagedMessage = new StringBuilder();
        stagedMessage.append("The following languages mappings are available, please select one: [default: EN] \n");

        StringBuilder groupedLangList = new StringBuilder(">\t"); String input;
        int groupedLangCount = 0;

        for (String availableLanguage: availableLangList) {
            groupedLangCount++;
            groupedLangList.append(availableLanguage).append("\t");

            if (groupedLangCount == 6) {
                stagedMessage.append(groupedLangList).append("\n");
                groupedLangCount = 0;
                groupedLangList = new StringBuilder(">\t");
            }
        }

        if (groupedLangCount > 0) {
            stagedMessage.append(groupedLangList).append("\n");
        }

        stagedMessage.append("\nYour choice: [EN] ");

        input = Grasscutter.getConsole().readLine(stagedMessage.toString());
        if (availableLangList.contains(input.toLowerCase())) {
            return input.toUpperCase();
        }

        Grasscutter.getLogger().info("Invalid option. Will use EN (English) as fallback."); return "EN";
    }
}
