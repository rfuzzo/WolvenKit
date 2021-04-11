using System.IO;
using WolvenKit.RED4.TweakDB.Extensions;

namespace WolvenKit.RED4.TweakDB.Types
{
    public class Vector2 : IVariable
    {
        public float X { get; set; }
        public float Y { get; set; }
        public string Unknown { get; set; }

        public void Read(BinaryReader file)
        {
            file.ReadByte(); // unknown
            X = VariableHelper.ReadProperty<float>(file);
            Y = VariableHelper.ReadProperty<float>(file);
            Unknown = file.ReadLengthPrefixedString();
        }

        public void Write(BinaryWriter file) => throw new System.NotImplementedException();
    }
}
