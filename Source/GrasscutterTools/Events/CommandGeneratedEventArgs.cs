using System;

namespace GrasscutterTools.Events
{
    public class CommandGeneratedEventArgs : EventArgs
    {
        public CommandGeneratedEventArgs(string command = "")
        {
            Command = command;
        }

        public string Command { get; set; }
    }
}
