using System.IO;
using WolvenKit.RED4.TweakDB.Extensions;

namespace WolvenKit.RED4.TweakDB.Types
{
    public class CName : IVariable
    {
        public string Value { get; set; }

        public void Read(BinaryReader file) => Value = file.ReadLengthPrefixedString();

        public void Write(BinaryWriter file) => throw new System.NotImplementedException();

        public override string ToString() => Value;
    }
}
