using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using WolvenKit.Common;
using WolvenKit.Common.FNV1A;
using WolvenKit.RED4.TweakDB.Types;

namespace WolvenKit.RED4.TweakDB
{
    /*
    var tweakDbStrFile = new TweakDBStringFile();

    var tweakDbStrReader = new BinaryReader(File.OpenRead("tweakdb.str"));
    tweakDbStrFile.Read(tweakDbStrReader);

    var tweakDbReader = new BinaryReader(File.OpenRead("tweakdb.bin"));
    var tweakDbFile = new TweakDBFile(tweakDbStrFile);
    tweakDbFile.ParseTypes("types.csv");
    tweakDbFile.Read(tweakDbReader);
     */
    public class TweakDBFile
    {
        #region Constants

        public const uint MAGIC = 0x0bb1db47;

        #endregion

        #region Fields

        private static Dictionary<string, Type> _internalTypeDict = new()
        {
            {"Int8", typeof(CInt8)},
            {"Uint8", typeof(CUInt8)},
            {"Int16", typeof(CInt16)},
            {"Uint16", typeof(CUInt16)},
            {"Int32", typeof(CInt32)},
            {"Uint32", typeof(CUInt32)},
            {"Int64", typeof(CInt64)},
            {"Uint64", typeof(CUInt64)},
            {"Bool", typeof(CBool)},
            {"Float", typeof(CFloat)},
            {"Double", typeof(CDouble)},
            {"String", typeof(CString)},
            {"CName", typeof(CName)},
            {"Color", typeof(CColor)},
            {"EulerAngles", typeof(EulerAngles)},
            {"Quaternion", typeof(Quaternion)},
            {"TweakDBID", typeof(TweakDBID)},
            {"Vector2", typeof(Vector2)},
            {"Vector3", typeof(Vector3)},
            {"Vector4", typeof(Vector4)},
            {"CResource", typeof(CResource)},
            {"raRef:CResource", typeof(Types.raRef<CResource>)},
            {"LocalizationString", typeof(LocalizationString)},
            {"gamedataLocKeyWrapper", typeof(gamedataLocKeyWrapper)}
        };

        private static Dictionary<uint, Type> _recordTypeDict = new();

        #endregion

        #region Properties

        public Dictionary<ulong, Type> Types = new();
        public TweakDBStringFile StringFile { get; }
        

        public Dictionary<TweakDBID, IVariable> FlatDict { get; set; } = new();
        public Dictionary<Type, gamedataTweakDBRecord> DefaultTypeDataDict { get; set; } = new();
        public Dictionary<TweakDBID, gamedataTweakDBRecord> RecordDict { get; set; } = new();
        public Dictionary<TweakDBID, List<TweakDBID>> QueryDict { get; set; } = new();
        public Dictionary<TweakDBID, GroupTag> GroupTagDict { get; set; } = new();

        #endregion

        public TweakDBFile()
        {
            Initialize();
        }

        public TweakDBFile(TweakDBStringFile stringFile)
        {
            StringFile = stringFile;

            Initialize();
        }

        private void Initialize()
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (typeof(gamedataTweakDBRecord).IsAssignableFrom(type) && type != typeof(gamedataTweakDBRecord))
                {
                    var hash = MurMurHash3.GetHash(type.Name[8..^7]);

                    _recordTypeDict.Add(hash, type);
                }
            }
        }

        // path to types.csv
        public void ParseTypes(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                AddType(line.Split('\t')[1]);
            }
        }

        public void AddType(string redTypeName)
        {
            var hash64 = FNV1A64HashAlgorithm.HashString(redTypeName, Encoding.GetEncoding("iso-8859-1"), false, true);

            var isArray = redTypeName.StartsWith("array:");
            if (isArray)
            {
                redTypeName = redTypeName["array:".Length..];
            }

            if (!_internalTypeDict.ContainsKey(redTypeName))
                throw new NotImplementedException();

            var type = _internalTypeDict[redTypeName];
            if (isArray)
            {
                type = typeof(Types.CArray<>).MakeGenericType(type);
            }

            Types.Add(hash64, type);
        }

        public void Read(BinaryReader file)
        {
            // read file header
            var id = file.BaseStream.ReadStruct<uint>();
            if (id != MAGIC)
                return;

            var fileheader = file.BaseStream.ReadStruct<TweakDBFileHeader>();

            var flatIndex = file.BaseStream.ReadStructs<FlatIndexEntry>(file.ReadUInt32()).Select(_ => new FlatIndexEntryWrapper(_, this)).ToList();
            foreach (var indexEntry in flatIndex)
            {
                ReadFlatPair(file, indexEntry);
            }

            var size = file.ReadInt32();
            for (int i = 0; i < size; i++)
            {
                var tweakDbId = new TweakDBID(file.ReadUInt64());
                tweakDbId.SetTweakDBFile(this);

                var typeHash = file.ReadUInt32();

                var cls = (gamedataTweakDBRecord)System.Activator.CreateInstance(_recordTypeDict[typeHash]);
                cls.SetTweakDBFile(this);
                cls.SetBaseTweakDbId(tweakDbId);

                RecordDict.Add(tweakDbId, cls);
            }

            size = file.ReadInt32();
            for (int i = 0; i < size; i++)
            {
                var tweakDbId = new TweakDBID(file.ReadUInt64());
                tweakDbId.SetTweakDBFile(this);

                var value = new List<TweakDBID>();

                var size2 = file.ReadInt32();
                for (int j = 0; j < size2; j++)
                {
                    var subVal = new TweakDBID(file.ReadUInt64());
                    subVal.SetTweakDBFile(this);

                    value.Add(subVal);
                }

                QueryDict.Add(tweakDbId, value);
            }

            size = file.ReadInt32();
            for (int i = 0; i < size; i++)
            {
                var tweakDbId = new TweakDBID(file.ReadUInt64());
                tweakDbId.SetTweakDBFile(this);

                var value = (GroupTag)file.ReadByte();

                GroupTagDict.Add(tweakDbId, value);
            }

            foreach (var recordType in _recordTypeDict)
            {
                var name = $"RTDB.{recordType.Value.Name[8..^7]}";
                var tweakDbId = new TweakDBID(name);
                tweakDbId.SetTweakDBFile(this);

                var cls = (gamedataTweakDBRecord)System.Activator.CreateInstance(recordType.Value);
                cls.SetTweakDBFile(this);
                cls.SetBaseTweakDbId(tweakDbId);

                DefaultTypeDataDict.Add(recordType.Value, cls);
            }
        }

        private void ReadFlatPair(BinaryReader file, FlatIndexEntryWrapper flatIndex)
        {
            var valueList = new List<IVariable>();

            var size = file.ReadInt32();
            for (var i = 0; i < size; i++)
            {
                var cvar = flatIndex.Create();
                cvar.Read(file);

                if (cvar is TweakDBID tweakDbId)
                {
                    tweakDbId.SetTweakDBFile(this);
                }

                if (cvar is CArray<TweakDBID> arr)
                {
                    foreach (var tweakDbId2 in arr.Value)
                    {
                        tweakDbId2.SetTweakDBFile(this);
                    }
                }

                valueList.Add(cvar);
            }

            size = file.ReadInt32();
            for (int i = 0; i < size; i++)
            {
                var tweakDbId = new TweakDBID(file.ReadUInt64());
                tweakDbId.SetTweakDBFile(this);

                var value = valueList[file.ReadInt32()];

                FlatDict.TryAdd(tweakDbId, value);
            }
        }

        public void Write(BinaryWriter file)
        {
            // need to find out all the hashes (TweakDBFileHeader and FlatIndexEntry)
            throw new NotImplementedException();
        }
    }
}
