using System.IO;

namespace WolvenKit.RED4.TweakDB.Types
{
    public interface IVariable
    {
        public void Read(BinaryReader file);
        public void Write(BinaryWriter file);
    }
}
