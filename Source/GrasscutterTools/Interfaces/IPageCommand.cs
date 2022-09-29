using System;

using GrasscutterTools.Events;

namespace GrasscutterTools.Interfaces
{
    public interface IPageCommand
    {
        event EventHandler<CommandGeneratedEventArgs> CommandGenerated;
    }
}
