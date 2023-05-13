/**
 *  Grasscutter Tools
 *  Copyright (C) 2023 jie65535
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Affero General Public License as published
 *  by the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 *
 **/

using System.Collections.Generic;

namespace GrasscutterTools.Game.Props
{
    internal class PlayerProperty
    {
        public static List<PlayerProperty> Values { get; } = new List<PlayerProperty> {
            new PlayerProperty("EXP", 0),
            new PlayerProperty("BREAK_LEVEL"),
            new PlayerProperty("SATIATION_VAL"),
            new PlayerProperty("SATIATION_PENALTY_TIME"),
            new PlayerProperty("LEVEL", 0, 90),
            new PlayerProperty("LAST_CHANGE_AVATAR_TIME"),
            new PlayerProperty("MAX_SPRING_VOLUME", 0, 8_500_000, description: "Maximum volume of the Statue of the Seven for the player [0, 8500000]"),
            new PlayerProperty("CUR_SPRING_VOLUME", description: "Current volume of the Statue of the Seven [0, MAX_SPRING_VOLUME]"),
            new PlayerProperty("IS_SPRING_AUTO_USE", 0, 1, description: "Auto HP recovery when approaching the Statue of the Seven [0, 1]"),
            new PlayerProperty("SPRING_AUTO_USE_PERCENT", 0, 100, description: "Auto HP recovery percentage [0, 100]"),
            new PlayerProperty("IS_FLYABLE", 0, 1, description: "Are you in a state that disables your flying ability? e.g. new player [0, 1]"),
            new PlayerProperty("IS_WEATHER_LOCKED", 0, 1),
            new PlayerProperty("IS_GAME_TIME_LOCKED", 0, 1),
            new PlayerProperty("IS_TRANSFERABLE", 0, 1),
            new PlayerProperty("MAX_STAMINA", 0, 24_000, description: "Maximum stamina of the player (0 - 24000)"),
            new PlayerProperty("CUR_PERSIST_STAMINA", description: "Used stamina of the player (0 - MAX_STAMINA)"),
            new PlayerProperty("CUR_TEMPORARY_STAMINA"),
            new PlayerProperty("PLAYER_LEVEL", 1, 60),
            new PlayerProperty("PLAYER_EXP"),
            new PlayerProperty("PLAYER_HCOIN", description: "Primogem (-inf, +inf)"), // It is known that Mihoyo will make Primogem negative in the cases that a player spends his gems and then got a money refund, so negative is allowed.
            new PlayerProperty("PLAYER_SCOIN", 0, description: "Mora [0, +inf)"),
            new PlayerProperty("PLAYER_MP_SETTING_TYPE", 0, 2, description: "Do you allow other players to join your game? [0=no 1=direct 2=approval]"),
            new PlayerProperty("IS_MP_MODE_AVAILABLE", 0, 1, description: "0 if in quest or something that disables MP [0, 1]"),
            new PlayerProperty("PLAYER_WORLD_LEVEL", 0, 8, description: "[0, 8]"),
            new PlayerProperty("PLAYER_RESIN", 0, 2000, description: "Original Resin [0, 2000] - note that values above 160 require refills"),
            new PlayerProperty("PLAYER_WAIT_SUB_HCOIN"),
            new PlayerProperty("PLAYER_WAIT_SUB_SCOIN"),
            new PlayerProperty("IS_ONLY_MP_WITH_PS_PLAYER", 0, 1, description: "Is only MP with PlayStation players? [0, 1]"),
            new PlayerProperty("PLAYER_MCOIN", description: "Genesis Crystal (-inf, +inf) see 10015"),
            new PlayerProperty("PLAYER_WAIT_SUB_MCOIN"),
            new PlayerProperty("PLAYER_LEGENDARY_KEY", 0),
            new PlayerProperty("IS_HAS_FIRST_SHARE"),
            new PlayerProperty("PLAYER_FORGE_POINT", 0, 300_000),
            new PlayerProperty("CUR_CLIMATE_METER"),
            new PlayerProperty("CUR_CLIMATE_TYPE"),
            new PlayerProperty("CUR_CLIMATE_AREA_ID"),
            new PlayerProperty("CUR_CLIMATE_AREA_CLIMATE_TYPE"),
            new PlayerProperty("PLAYER_WORLD_LEVEL_LIMIT"),
            new PlayerProperty("PLAYER_WORLD_LEVEL_ADJUST_CD"),
            new PlayerProperty("PLAYER_LEGENDARY_DAILY_TASK_NUM"),
            new PlayerProperty("PLAYER_HOME_COIN", 0, description: "Realm currency [0, +inf)"),
            new PlayerProperty("PLAYER_WAIT_SUB_HOME_COIN")
        };

        public string Id { get; }
        public string Name { get; set; }
        public int Min { get; }
        public int Max { get; }
        public string Description { get; set; }

        private PlayerProperty(string id, int min = int.MinValue, int max = int.MaxValue, string description = "")
        {
            Id = id;
            Min = min;
            Max = max;
            Description = description;
        }
    }
}