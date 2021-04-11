using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using RED.CRC32;

namespace WolvenKit.RED4.TweakDB.Types
{
    public class RecordType
    {
        public string ClassName { get; set; }
        public string Name => ClassName[8..^7];
        public uint Hash =>MurMurHash3.GetHash(Name);
        public RecordType BaseType { get; set; }
        public ConcurrentBag<RecordProperty> Properties { get; set; } = new();

        public bool ContainsProp(string name) => GetProperty(name) != null;

        public RecordProperty GetProperty(string name)
        {
            foreach (var recordProperty in Properties)
            {
                if (recordProperty.Name == name)
                {
                    return recordProperty;
                }
            }

            return BaseType?.GetProperty(name);
        }

        public List<RecordProperty> GetAllProperties()
        {
            var result = new List<RecordProperty>();
            foreach (var property in Properties)
            {
                result.Add(property);
            }

            if (BaseType != null)
            {
                result.AddRange(BaseType.GetAllProperties());
            }

            return result;
        }
    }

    public class RecordProperty
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public override string ToString() => Name;
    }
}
