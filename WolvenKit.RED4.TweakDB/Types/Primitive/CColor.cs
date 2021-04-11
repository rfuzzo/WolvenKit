using System.IO;
using System.Runtime.InteropServices;
using WolvenKit.RED4.TweakDB.Extensions;

namespace WolvenKit.RED4.TweakDB.Types
{
    public class CColor : IVariable
    {
        private Color _value;

        public Color Value
        {
            get => _value;
            set => _value = value;
        }

        public void Read(BinaryReader file) => file.Read<Color>();
        public void Write(BinaryWriter file) => file.Write(Value);
    }

    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct Color
    {
        [FieldOffset(0)]
        public byte R;

        [FieldOffset(1)]
        public byte G;

        [FieldOffset(2)]
        public byte B;

        [FieldOffset(3)]
        public byte A;
    }
}
