using System.Collections.Generic;
using System.IO;

namespace WolvenKit.RED4.TweakDB.Types
{
    public class CArray<T> : IVariable where T : IVariable
    {
        public List<T> Value { get; set; } = new();

        public void Read(BinaryReader file)
        {
            var size = file.ReadInt32();
            for (var i = 0; i < size; i++)
            {
                var element = System.Activator.CreateInstance<T>();
                element.Read(file);
                Value.Add(element);
            }
        }

        public void Write(BinaryWriter file) => throw new System.NotImplementedException();
    }
}
