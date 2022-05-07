namespace GrasscutterTools.Game
{
    public class GameCommand
    {
        public GameCommand(string name, string command)
        {
            Name=name;
            Command=command;
        }

        public string Name { get; set; }

        public string Command { get; set; }
    }
}
