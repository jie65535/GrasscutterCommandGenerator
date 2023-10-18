# Grasscutter Tools

[![GitHub лицензия](https://img.shields.io/github/license/jie65535/GrasscutterCommandGenerator)](https://github.com/jie65535/GrasscutterCommandGenerator/blob/main/LICENSE)
[![GitHub звёзды](https://img.shields.io/github/stars/jie65535/GrasscutterCommandGenerator)](https://github.com/jie65535/GrasscutterCommandGenerator/stargazers)
[![Github ВСЕ выпуски](https://img.shields.io/github/downloads/jie65535/GrasscutterCommandGenerator/total.svg)](https://github.com/jie65535/GrasscutterCommandGenerator/releases)
[![GitHub release](https://img.shields.io/github/v/release/jie65535/GrasscutterCommandGenerator)](https://github.com/jie65535/GrasscutterCommandGenerator/releases/latest)
[![Build](https://github.com/jie65535/GrasscutterCommandGenerator/actions/workflows/build.yml/badge.svg)](https://github.com/jie65535/GrasscutterCommandGenerator/actions/workflows/build.yml)

[English](README.md) | [简体中文](README_zh-cn.md) | [繁體中文](README_zh-tw.md) | Русский - Перевод [Юрий Дворецкий](https://github.com/yurikenjx) (с исправлениями от [EgorBron](https://github.com/EgorBron)) 

## Генератор команд (GCG)

Пожалуйста, загрузите последнюю подтвержденную автоматизированную сборку из [Action](https://github.com/jie65535/GrasscutterCommandGenerator/actions/workflows/build.yml) или выпуск из [Releases](https://github.com/jie65535/GrasscutterCommandGenerator/releases) (может отставать)

GCG поддерживает 简体中文 (китайский упр.), 繁體中文 (китайский трад.), English (английский) и Русский языки.

> **Warning**: вид приложения может отличаться от скриншотов. Также в нём могут присутствовать ошибки в переводе и отсутсвие некоторых ресурсов. **Мы приглашаем всех сделать вклад в их [улучшение](/Source/GrasscutterTools/Resources/ru-ru)**

## Удаленная команда (OpenCommand)

Чтобы использовать команды прямо из GCG, серверу требуется плагин [gc-opencommand-plugin](https://github.com/jie65535/gc-opencommand-plugin).

![Open Command](Doc/Screenshots/OpenCommand.gif)

> Если вы не можете подключиться к серверу, проверьте правильность написания его URL-адреса.
>
> Рекомендуется изменить секцию HTTP в конфиге как на скриншоте ниже (конфиг - файл config.json):
>
> ![ConfigHttp](Doc/Screenshots/ConfigHttp.png)
>
> Для проверки можете посетить http://127.0.0.1/status/server в браузере, чтобы проверить работоспособность OpenCommand.
>
> Если вы не указали порт `80` в конфиге, вам нужно указать свой порт в URL-адресе (например, http://127.0.0.1:443)


## Лог обновлений

### GrasscutterTools-v1.13
![Proxy](Doc/Screenshots-en/22-Proxy.png)

![SceneTag](Doc/Screenshots-en/23-SceneTag.png)

![Weather](Doc/Screenshots-en/24-Weather.png)

![Settings](Doc/Screenshots-en/25-Settings.png)

### GrasscutterTools-v1.11
![HotKey](Doc/Screenshots-en/21-HotKey.png)

Commandline Usages:
```bash
GcTools.exe -help
GcTools.exe -version
GcTools.exe -c "cmd arg"
GcTools.exe -c "cmd1 arg" && GcTools -c "cmd2 arg1 arg2"
GcTools.exe -host http://127.0.0.1:443 -token 123456 -c "cmd1 arg1 arg2 | cmd2 | cmd3 arg"
```

### GrasscutterTools-v1.10
![Cutscene](Doc/Screenshots-ru/12-Scenes.png)

![Activity Editor](Doc/Screenshots-ru/20-ActivityEditor.png)

### GrasscutterTools-v1.9
![Achievement Page](Doc/Screenshots-ru/19-AchievementPage.png)

### GrasscutterTools-v1.8
![Task page](Doc/Screenshots-ru/18-TaskPage.png)

### GrasscutterTools-v1.7.3
![Улучшенный спавн](Doc/Screenshots-ru/5-Spawn.png)

Добавлена поддержка генерации команд для плагинов [AttackModifier](https://github.com/NotThorny/AttackModifier), [AttackInfusedWithItem](https://github.com/snoobi-seggs/AttackInfusedWithItem), [SwitchElementTraveller](https://github.com/Penelopeep/SwitchElementTraveller).

![AttackInfusedWithItem Gif](Doc/Screenshots/AttackMod.gif)

### GrasscutterTools-v1.7.2
![Редактор магазина](Doc/Screenshots-ru/13-Shop.png)

### GrasscutterTools-v1.7.1
 - Гаджеты (пока что только на китайском)

### GrasscutterTools-v1.7.0

![Запуск нескольких команд](Doc/Screenshots/RunMultipleCommands.png)

![Редактор дропа](Doc/Screenshots-ru/15-Drops.png)

![Редактор писем](Doc/Screenshots-ru/10-Mail.png)

---

## Скриншоты

![Логитип](Doc/Screenshots/GrasscutterLogo.png)

![Главная](Doc/Screenshots-ru/1-Home.png)

![OpenCommand](Doc/Screenshots-ru/2-Opencommand.png)

![Кастомные команды](Doc/Screenshots-ru/3-Custom.png)

![Артефакты](Doc/Screenshots-ru/4-Artifacts.png)

![Спавн сущностей](Doc/Screenshots-ru/5-Spawn.png)

![Выдача предметов](Doc/Screenshots-ru/6-Give.png)

![Выдача персонажей](Doc/Screenshots-ru/7-Character.png)

![Выдача оружий](Doc/Screenshots-ru/8-Weapons.png)

![Управление аккаунтами](Doc/Screenshots-ru/9-Accounts.png)

![Почта](Doc/Screenshots-ru/10-Mail.png)

![Квесты](Doc/Screenshots-ru/11-Quests.png)

![Сцены](Doc/Screenshots-ru/12-Scenes.png)

![Редактор магазина](Doc/Screenshots-ru/13-Shop.png)

![Редактор баннеров](Doc/Screenshots-ru/14-Gachas.png)

![Редактор дропа](Doc/Screenshots-ru/14-Drops.png)

![Браузер текстов](Doc/Screenshots-ru/16-Textmaps.png)