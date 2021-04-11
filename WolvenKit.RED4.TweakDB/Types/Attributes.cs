using System;

namespace WolvenKit.RED4.TweakDB.Types
{
    public class REDAttribute : Attribute
    {
        public string Name { get; }

        public REDAttribute(string name)
        {
            Name = name;
        }
    }
}
