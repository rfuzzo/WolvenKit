using System;
using System.IO;

namespace WolvenKit.RED4.TweakDB.Types
{
    public class gamedataLocKeyWrapper : IVariable
    {
        public ulong Value { get; set; }

        public void Read(BinaryReader file) => Value = file.ReadUInt64();

        public void Write(BinaryWriter file) => throw new NotImplementedException();
    }
}
