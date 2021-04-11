using System.Collections.Generic;
using WolvenKit.RED4.TweakDB.Types;

namespace WolvenKit.RED4.TweakDB
{
    public class TweakDBGroup
    {
        private List<TweakDBRecord> _records;

        public string Name { get; }
        

        public TweakDBGroup(string name)
        {
            Name = name;

            _records = new List<TweakDBRecord>();
        }

        public void AddRecord(string name, uint value)
        {
            _records.Add(new TweakDBRecord(name, value));
        }

        public TweakDBRecord GetRecord(string name)
        {
            foreach (var record in _records)
            {
                if (record.Name == name)
                {
                    return record;
                }
            }

            return null;
        }

        public override string ToString() => $"TweakDBGroup[\"{Name}\", {_records.Count}]";
    }

    public class TweakDBRecord
    {
        public string Name { get; }
        public uint Value { get; }
        public Dictionary<string, IVariable> Properties { get; set; }

        public TweakDBRecord(string name, uint value)
        {
            Name = name;
            Value = value;

            Properties = new();
        }

        public void AddProperty(string name, IVariable value)
        {
            Properties.Add(name, value);
        }

        public override string ToString() => $"TweakDBRecord[\"{Name}\"]";
    }
}
