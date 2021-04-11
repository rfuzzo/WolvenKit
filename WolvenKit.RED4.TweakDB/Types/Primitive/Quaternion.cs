using System;
using System.IO;
using System.Runtime.InteropServices;
using WolvenKit.RED4.TweakDB.Extensions;

namespace WolvenKit.RED4.TweakDB.Types
{
    public class Quaternion : IVariable
    {
        public float i { get; set; }
        public float j { get; set; }
        public float k { get; set; }
        public float r { get; set; }
        public string Unknown { get; set; }

        public void Read(BinaryReader file)
        {
            file.ReadByte(); // unknown
            i = VariableHelper.ReadProperty<float>(file);
            j = VariableHelper.ReadProperty<float>(file);
            k = VariableHelper.ReadProperty<float>(file);
            r = VariableHelper.ReadProperty<float>(file);
            Unknown = file.ReadLengthPrefixedString();
        }

        public void Write(BinaryWriter file) => throw new NotImplementedException();
    }
}
