using System.IO;

namespace WolvenKit.RED4.TweakDB.Types
{
    /// <summary>
    /// CSofts are Uint16 references to the imports table of a cr2w file
    /// Imports are paths to a file in the tw3 filesystem
    /// and can be set manually by DepotPath and Classname
    /// Imports have flags which are set on write
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class raRef<T> : IVariable where T : IVariable
    {
        public ulong Value { get; set; }

        public void Read(BinaryReader file) => Value = file.ReadUInt64();

        public void Write(BinaryWriter file) => throw new System.NotImplementedException();
    }
}
