using System.Collections.Generic;
using System.IO;
using WolvenKit.RED4.TweakDB.Extensions;
using WolvenKit.RED4.TweakDB.Types;

namespace WolvenKit.RED4.TweakDB
{
    // Reader for tweakdb.str
    public class TweakDBStringFile
    {
        #region Constants

        public const uint MAGIC = 0x0bb1db57;

        #endregion

        #region Fields

        private TweakDBStringFileHeader m_fileheader;

        #endregion

        #region Properties

        public Dictionary<ulong, string> Table1 { get; set; } = new();
        public Dictionary<ulong, string> Table2 { get; set; } = new();
        public Dictionary<ulong, string> Table3 { get; set; } = new();

        #endregion

        public TweakDBStringFile() { }

        public void Read(BinaryReader file)
        {
            // read file header
            var id = file.Read<uint>();
            if (id != MAGIC)
                return;

            m_fileheader = file.Read<TweakDBStringFileHeader>();

            for (var i = 0; i < m_fileheader.Unknown2; i++)
            {
                var name = file.ReadLengthPrefixedString();
                var tweakDbId = new TweakDBID(name);

                Table1.Add(tweakDbId.Value, name);
            }

            for (var i = 0; i < m_fileheader.Unknown3; i++)
            {
                var name = file.ReadLengthPrefixedString();
                var tweakDbId = new TweakDBID(name);

                Table2.Add(tweakDbId.Value, name);
            }

            for (var i = 0; i < m_fileheader.Unknown4; i++)
            {
                var name = file.ReadLengthPrefixedString();
                var tweakDbId = new TweakDBID(name);

                Table3.Add(tweakDbId.Value, name);
            }
        }

        public string GetName(TweakDBID tweakDbid)
        {
            if (Table1.ContainsKey(tweakDbid.Value))
            {
                return Table1[tweakDbid.Value];
            }

            if (Table2.ContainsKey(tweakDbid.Value))
            {
                return Table2[tweakDbid.Value];
            }

            if (Table3.ContainsKey(tweakDbid.Value))
            {
                return Table3[tweakDbid.Value];
            }

            return $"{tweakDbid.Value:X}".PadLeft(16, '0');
        }
    }
}
