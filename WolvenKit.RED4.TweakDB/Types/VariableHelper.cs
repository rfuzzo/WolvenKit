using System.IO;
using WolvenKit.RED4.TweakDB.Extensions;

namespace WolvenKit.RED4.TweakDB.Types
{
    public static class VariableHelper
    {
        public static T ReadProperty<T>(BinaryReader file) where T : struct
        {
            var propName = file.ReadLengthPrefixedString();
            var propType = file.ReadLengthPrefixedString();
            var size = file.ReadInt32();
            return file.Read<T>();
        }
    }
}
