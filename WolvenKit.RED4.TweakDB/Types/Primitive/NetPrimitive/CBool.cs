using System.IO;

namespace WolvenKit.RED4.TweakDB.Types
{
    public class CBool : IVariable
    {
        private bool _value;

        public bool Value
        {
            get => _value;
            set => _value = value;
        }

        public void Read(BinaryReader file) => Value = file.ReadBoolean();

        public void Write(BinaryWriter file) => file.Write(Value);

        public override string ToString() => Value ? "True" : "False";
    }
}
