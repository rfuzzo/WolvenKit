using System.Runtime.InteropServices;

namespace WolvenKit.RED4.TweakDB
{
    [StructLayout(LayoutKind.Explicit, Size = 28)]
    public struct TweakDBFileHeader
    {
        [FieldOffset(0)]
        public uint blobVersion;

        [FieldOffset(4)]
        public uint parserVersion;

        [FieldOffset(8)]
        public uint recordsChecksum;

        [FieldOffset(12)]
        public uint flatOffset;

        [FieldOffset(16)]
        public uint recordsOffset;

        [FieldOffset(20)]
        public uint queriesOffset;

        [FieldOffset(24)]
        public uint groupTagsOffset;
    }

    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct TweakDBStringFileHeader
    {
        [FieldOffset(0)]
        public uint Unknown1;

        [FieldOffset(4)]
        public uint Unknown2;

        [FieldOffset(8)]
        public uint Unknown3;

        [FieldOffset(12)]
        public uint Unknown4;
    }
}
