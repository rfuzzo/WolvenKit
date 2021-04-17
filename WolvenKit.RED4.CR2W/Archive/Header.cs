using System.IO;
using WolvenKit.RED4.CR2W.Types;
using ZeroFormatter;

namespace CP77Tools.Model
{


    [ZeroFormattable]
    public class Header
    {
        #region Fields

        public const uint MAGIC = 1380009042;
        public const int SIZE = 40;

        #endregion Fields

        #region Constructors

        public Header()
        {
            Magic = MAGIC;
            Version = 12;
            DebugPosition = 0;
            DebugSize = 0;
        }

        public Header(BinaryReader br)
        {
            Read(br);
        }

        #endregion Constructors

        #region Properties

        [Index(0)] public virtual ulong DebugPosition { get; set; }
        [Index(1)] public virtual uint DebugSize { get; set; }
        [Index(2)] public virtual ulong Filesize { get; set; }
        [Index(3)] public virtual ulong IndexPosition { get; set; }
        [Index(4)] public virtual uint IndexSize { get; set; }
        [Index(5)] public virtual uint Magic { get; set; }
        [Index(6)] public virtual uint Version { get; set; }

        #endregion Properties

        #region Methods

        public void Write(BinaryWriter bw)
        {
            bw.Write(MAGIC);
            bw.Write(Version);
            bw.Write(IndexPosition);
            bw.Write(IndexSize);
            bw.Write(DebugPosition);
            bw.Write(DebugSize);
            bw.Write(Filesize);
        }

        private void Read(BinaryReader br)
        {
            Magic = br.ReadUInt32();
            if (Magic != MAGIC)
                throw new InvalidParsingException("not an ArchiveHeader");

            Version = br.ReadUInt32();
            IndexPosition = br.ReadUInt64();
            IndexSize = br.ReadUInt32();
            DebugPosition = br.ReadUInt64();
            DebugSize = br.ReadUInt32();
            Filesize = br.ReadUInt64();
        }

        #endregion Methods
    }
}
