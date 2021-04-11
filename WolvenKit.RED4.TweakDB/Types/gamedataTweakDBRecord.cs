using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using RED.CRC32;

namespace WolvenKit.RED4.TweakDB.Types
{
    public class gamedataTweakDBRecord
    {
        private Dictionary<string, TweakDBID> _propertyCache = new();

        private TweakDBFile _file;
        private TweakDBID _baseTweakDbId;

        public T GetProperty<T>([CallerMemberName] string callerMemberName = "", bool isDefaultType = false) where T : IVariable
        {
            if (!_propertyCache.ContainsKey(callerMemberName))
            {
                var propertyInfo = GetType().GetProperty(callerMemberName);
                var redName = propertyInfo.GetCustomAttribute<REDAttribute>().Name;
                var redBuffer = System.Text.Encoding.ASCII.GetBytes("." + redName);
                var propHash = Crc32Algorithm.Append(_baseTweakDbId.Hash, redBuffer);
                var tmp = ((ulong)(_baseTweakDbId.Length + redBuffer.Length) << 32) + propHash;

                _propertyCache.Add(callerMemberName, new TweakDBID(tmp));
            }

            if (_file.FlatDict.ContainsKey(_propertyCache[callerMemberName]))
            {
                return (T)_file.FlatDict[_propertyCache[callerMemberName]];
            }

            if (!isDefaultType)
            {
                return _file.DefaultTypeDataDict[GetType()].GetProperty<T>(callerMemberName, true);
            }

            return default;
        }

        public void SetProperty<T>(T value, [CallerMemberName] string callerMemberName = "") where T : IVariable
        {
            throw new NotImplementedException();
        }

        public void DeleteAllFlats()
        {
            foreach (var propertyInfo in GetType().GetProperties())
            {
                var redName = propertyInfo.GetCustomAttribute<REDAttribute>().Name;
                var redBuffer = System.Text.Encoding.ASCII.GetBytes("." + redName);
                var propHash = Crc32Algorithm.Append(_baseTweakDbId.Hash, redBuffer);
                var tmp = ((ulong)(_baseTweakDbId.Length + redBuffer.Length) << 32) + propHash;
                var t = new TweakDBID(tmp);

                _file.FlatDict.Remove(t);
            }
        }

        public void SetTweakDBFile(TweakDBFile file) => _file = file;
        public void SetBaseTweakDbId(TweakDBID tweakDbId) => _baseTweakDbId = tweakDbId;

        public uint GetTweakBaseHash() => MurMurHash3.GetHash(GetType().Name[8..^7]);
    }
}
