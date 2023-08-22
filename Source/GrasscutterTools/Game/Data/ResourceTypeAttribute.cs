using System;

namespace GrasscutterTools.Game.Data
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ResourceTypeAttribute : Attribute
    {
        public string Name { get; set; }

        public ResourceTypeAttribute(string name)
        {
            Name = name;
        }
    }
}
