using System;
using System.IO;
using Catel.IoC;
using WolvenKit.Common;
using WolvenKit.Common.Services;
using WolvenKit.RED4.CR2W.Types;
using ZeroFormatter;

namespace WolvenKit.RED4.CR2W.Archive
{

    [ZeroFormattable]
    public class FileEntry : IGameFile
    {
        #region Fields

        private string _nameStr;

        #endregion Fields

        #region Constructors

        public FileEntry()
        {
        }

        public FileEntry(BinaryReader br, IGameArchive parent)
        {
            Archive = parent;
            var mainController = ServiceLocator.Default.ResolveType<IHashService>();

            Read(br, mainController);
        }

        public FileEntry(ulong hash, DateTime datetime, uint flags
            , uint segmentsStart, uint segmentsEnd, uint resourceDependenciesStart, uint resourceDependenciesEnd, byte[] sha1hash)
        {
            NameHash64 = hash;
            Timestamp = datetime;
            NumInlineBufferSegments = flags;
            ResourceDependenciesStart = resourceDependenciesStart;
            ResourceDependenciesEnd = resourceDependenciesEnd;
            SegmentsStart = segmentsStart;
            SegmentsEnd = segmentsEnd;
            SHA1Hash = sha1hash;
        }

        #endregion Constructors

        #region Properties

        [Index(0)] new public virtual IGameArchive Archive { get; set; }
        [Index(1)]
        public virtual string bytesAsString
        {
            get { return BitConverter.ToString(SHA1Hash); }
            set { }
        }
        [Index(2)] new public virtual string CompressionType { get; set; }
        [Index(3)]
        public virtual string Extension
        {
            get { return Path.GetExtension(FileName); }
            set { }
        }
        [Index(4)]
        public virtual string FileName
        {
            get { return string.IsNullOrEmpty(_nameStr) ? $"{NameHash64}.bin" : _nameStr; }
            set { }
        }
        [Index(5)] new public virtual string Name { get; set; }
        [Index(6)] public virtual ulong NameHash64 { get; set; }
        [Index(7)]
        public virtual string NameOrHash
        {
            get { return string.IsNullOrEmpty(_nameStr) ? $"{NameHash64}" : _nameStr; }
            set { }
        }
        [Index(8)] public virtual uint NumInlineBufferSegments { get; set; }
        [Index(9)] new public virtual long PageOffset { get; set; }
        [Index(10)] public virtual uint ResourceDependenciesEnd { get; set; }
        [Index(11)] public virtual uint ResourceDependenciesStart { get; set; }
        [Index(12)] public virtual uint SegmentsEnd { get; set; }
        [Index(13)] public virtual uint SegmentsStart { get; set; }
        [Index(14)] public virtual byte[] SHA1Hash { get; set; }
        [Index(15)] new public virtual uint Size { get; set; }
        [Index(16)] public virtual DateTime Timestamp { get; set; }
        [Index(17)] new public virtual uint ZSize { get; set; }

        #endregion Properties

        #region Methods

        new public void Extract(Stream output)
        {
            if (Archive is not Archive ar)
                throw new InvalidParsingException($"{Archive.ArchiveAbsolutePath} is not a cyberpunk77 archive.");

            ar.CopyFileToStream(output, NameHash64, false);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(NameHash64);
            bw.Write(Timestamp.ToFileTime());
            bw.Write(NumInlineBufferSegments);
            bw.Write(SegmentsStart);
            bw.Write(SegmentsEnd);
            bw.Write(ResourceDependenciesStart);
            bw.Write(ResourceDependenciesEnd);
            bw.Write(SHA1Hash);
        }

        private void Read(BinaryReader br, IHashService hashService)
        {
            NameHash64 = br.ReadUInt64();
            _nameStr = hashService?.Get(NameHash64);

            // x-platform support
            if (System.Runtime.InteropServices.RuntimeInformation
                .IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
            {
                if (!string.IsNullOrEmpty(_nameStr) && _nameStr.Contains('\\'))
                    _nameStr = _nameStr.Replace('\\', Path.DirectorySeparatorChar);
            }

            Timestamp = DateTime.FromFileTime(br.ReadInt64());

            NumInlineBufferSegments = br.ReadUInt32();
            SegmentsStart = br.ReadUInt32();
            SegmentsEnd = br.ReadUInt32();
            ResourceDependenciesStart = br.ReadUInt32();
            ResourceDependenciesEnd = br.ReadUInt32();

            SHA1Hash = br.ReadBytes(20);

            if (!string.IsNullOrEmpty(_nameStr))
                Name = _nameStr;
            else
                Name = NameHash64.ToString();
        }

        #endregion Methods
    }
}
