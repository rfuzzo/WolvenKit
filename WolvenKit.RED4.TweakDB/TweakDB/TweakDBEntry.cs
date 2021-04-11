using System.Collections.Generic;
using WolvenKit.RED4.TweakDB.Types;

namespace WolvenKit.RED4.TweakDB
{
    public class TweakDBCollection
    {
        public Dictionary<string, TweakDBEntry> Childs { get; set; } = new();

        public TweakDBEntry CreateItem(string name)
        {
            var child = new TweakDBEntry {Name = name};
            Childs.Add(name, child);
            return child;
        }

        public TweakDBEntry FindItem(string name)
        {
            if (Childs.ContainsKey(name))
                return Childs[name];
            return null;
        }
    }

    public class TweakDBEntry
    {
        public int Index { get; set; } = -1;
        public string Name { get; set; }
        public IVariable Value { get; set; }
        public TweakDBCollection Childs { get; set; } = new();

        public override string ToString() => Name;
    }
}
