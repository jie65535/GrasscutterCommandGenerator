using System.Collections.Generic;
using System.Text;

/**
 *  Grasscutter Tools
 *  Copyright (C) 2022 jie65535
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

namespace GrasscutterTools.Game
{
    internal class GameCommand
    {
        public GameCommand(string name, string command)
        {
            Name = name;
            Command = command;
        }

        public string Name { get; set; }

        public string Command { get; set; }

        /// <summary>
        /// 获取命令记录
        /// （反序列化）
        /// </summary>
        /// <param name="commandsText">命令记录文本（示例："标签1\n命令1\n标签2\n命令2..."）</param>
        /// <returns>命令列表</returns>
        public static List<GameCommand> Parse(string commandsText)
        {
            var lines = commandsText.Split('\n');
            List<GameCommand> commands = new List<GameCommand>(lines.Length / 2);
            for (int i = 0; i < lines.Length - 1; i += 2)
                commands.Add(new GameCommand(lines[i].Trim(), lines[i + 1].Trim()));
            return commands;
        }

        /// <summary>
        /// 获取命令记录文本
        /// （序列化）
        /// </summary>
        /// <param name="commands">命令列表</param>
        /// <returns>命令记录文本（示例："标签1\n命令1\n标签2\n命令2..."）</returns>
        public static string ToString(List<GameCommand> commands)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var cmd in commands)
            {
                builder.AppendLine(cmd.Name);
                builder.AppendLine(cmd.Command);
            }
            return builder.ToString();
        }
    }
}