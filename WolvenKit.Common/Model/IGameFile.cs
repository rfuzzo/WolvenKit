using System.IO;
using ZeroFormatter;

namespace WolvenKit.Common
{
    /// <summary>
    /// Any game file
    /// </summary>
    ///
    [ZeroFormattable]
    public abstract class IGameFile
    {

        public IGameFile()
        {

        }
        #region Properties

        [Index(0)] public virtual IGameArchive Archive { get; set; }
        [Index(1)] public virtual string CompressionType { get; set; }
        [Index(2)] public virtual string Name { get; set; }

        /// <summary>
        /// !!! Double check when writing !!! Some files use 64bit, older files may use 32bit.
        /// </summary>
        [Index(3)] public virtual long PageOffset { get; set; }

        /// <summary>
        /// Uncompressed asset size in bytes
        /// </summary>
        [Index(4)] public virtual uint Size { get; set; }

        /// <summary>
        /// Compressed asset asize in bytes
        /// </summary>
        [Index(5)] public virtual uint ZSize { get; set; }

        #endregion Properties

        #region Methods

        public virtual void Extract(Stream output)
        {
            // I guess its happy now....
        }

        #endregion Methods
    }
}
