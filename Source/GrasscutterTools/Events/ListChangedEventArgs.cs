using System;
using System.Collections.Generic;

namespace GrasscutterTools.Events
{
    public class ListChangedEventArgs : EventArgs
    {
        public IEnumerable<string> List { get; set; }
    }
}
