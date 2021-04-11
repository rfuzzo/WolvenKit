using System.IO;
using WolvenKit.RED4.TweakDB.Extensions;

namespace WolvenKit.RED4.TweakDB.Types
{
    public class EulerAngles : IVariable
    {
        public float Pitch { get; set; }
        public float Yaw { get; set; }
        public float Roll { get; set; }
        public string Unknown { get; set; }

        public void Read(BinaryReader file)
        {
            file.ReadByte(); // unknown
            Pitch = VariableHelper.ReadProperty<float>(file);
            Yaw = VariableHelper.ReadProperty<float>(file);
            Roll = VariableHelper.ReadProperty<float>(file);
            Unknown = file.ReadLengthPrefixedString();
        }

        public void Write(BinaryWriter file) => throw new System.NotImplementedException();
    }
}
