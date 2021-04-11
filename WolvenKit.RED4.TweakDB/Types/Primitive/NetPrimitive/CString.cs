using System.IO;
using WolvenKit.RED4.TweakDB.Extensions;

namespace WolvenKit.RED4.TweakDB.Types
{
    public class CString : IVariable
    {
        private string _value;

        public string Value
        {
            get => _value;
            set => _value = value;
        }

        public void Read(BinaryReader file) => Value = file.ReadLengthPrefixedString();

        public void Write(BinaryWriter file) => file.WriteLengthPrefixedString(Value);

        public override string ToString() => Value;
    }
}
