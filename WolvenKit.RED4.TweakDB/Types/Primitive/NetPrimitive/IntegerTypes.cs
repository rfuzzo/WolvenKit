using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;

namespace WolvenKit.RED4.TweakDB.Types
{
    public class CFloat : IVariable
    {
        private float _value;

        public float Value
        {
            get => _value;
            set => _value = value;
        }

        public void Read(BinaryReader file) => Value = file.ReadSingle();
        public void Write(BinaryWriter file) => file.Write(Value);

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }

    public class CDouble : IVariable
    {
        private double _value;

        public double Value
        {
            get => _value;
            set => _value = value;
        }

        public void Read(BinaryReader file) => Value = file.ReadDouble();
        public void Write(BinaryWriter file) => file.Write(Value);

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }

    public class CUInt64 : IVariable
    {
        private ulong _value;

        public ulong Value
        {
            get => _value;
            set => _value = value;
        }

        public void Read(BinaryReader file) => Value = file.ReadUInt64();
        public void Write(BinaryWriter file) => file.Write(Value);


        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }

    public class CUInt32 : IVariable
    {
        private uint _value;

        public uint Value
        {
            get => _value;
            set => _value = value;
        }

        public void Read(BinaryReader file) => Value = file.ReadUInt32();
        public void Write(BinaryWriter file) => file.Write(Value);

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }

    public class CUInt16 : IVariable
    {
        private ushort _value;

        public ushort Value
        {
            get => _value;
            set => _value = value;
        }

        public void Read(BinaryReader file) => Value = file.ReadUInt16();
        public void Write(BinaryWriter file) => file.Write(Value);

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }

    public class CUInt8 : IVariable
    {
        private byte _value;

        public byte Value
        {
            get => _value;
            set => _value = value;
        }

        public void Read(BinaryReader file) => Value = file.ReadByte();
        public void Write(BinaryWriter file) => file.Write(Value);

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }

    public class CInt64 : IVariable
    {
        private long _value;

        public long Value
        {
            get => _value;
            set => _value = value;
        }

        public void Read(BinaryReader file) => Value = file.ReadInt64();
        public void Write(BinaryWriter file) => file.Write(Value);

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }

    public class CInt32 : IVariable
    {
        private int _value;

        public int Value
        {
            get => _value;
            set => _value = value;
        }

        public void Read(BinaryReader file) => Value = file.ReadInt32();
        public void Write(BinaryWriter file) => file.Write(Value);

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }

    public class CInt16 : IVariable
    {
        private short _value;

        public short Value
        {
            get => _value;
            set => _value = value;
        }

        public void Read(BinaryReader file) => Value = file.ReadInt16();
        public void Write(BinaryWriter file) => file.Write(Value);

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }

    public class CInt8 : IVariable
    {
        private sbyte _value;

        public sbyte Value
        {
            get => _value;
            set => _value = value;
        }

        public void Read(BinaryReader file) => Value = file.ReadSByte();
        public void Write(BinaryWriter file) => file.Write(Value);

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }
}
