using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using RED.CRC32;

namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class TweakDBID : IVariable, IEquatable<TweakDBID>
    {
        public uint Hash => (uint) (Value & 0xFFFFFFFF);

        public byte Length => (byte)(Value >> 32);

        public ulong Value { get; set; }

        public void Read(BinaryReader file) => Value = file.ReadUInt64();

        public void Write(BinaryWriter file) => throw new System.NotImplementedException();

        public TweakDBID() { }

        public TweakDBID(string val)
        {
            Value = GenerateHash(val);
        }

        public TweakDBID(ulong val)
        {
            Value = val;
        }

        private ulong GenerateHash(string val)
        {
            if (val.Length > 0xFF)
                throw new NotImplementedException();

            var buffer = Encoding.GetEncoding("iso-8859-1").GetBytes(val);
            var crc = Crc32Algorithm.Compute(buffer);

            return ((ulong)val.Length << 32) + crc;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((TweakDBID) obj);
        }

        public bool Equals(TweakDBID other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Value == other.Value;
        }

        public override int GetHashCode() => Value.GetHashCode();
    }

    /*[StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct TweakDBID
    {
        [FieldOffset(0)]
        public uint Hash;

        [FieldOffset(4)]
        public byte Length;

        [FieldOffset(5)]
        public byte Unknown1;

        [FieldOffset(6)]
        public byte Unknown2;

        [FieldOffset(7)]
        public byte Unknown3;


        [FieldOffset(0)]
        public ulong Value;
    }*/
}
