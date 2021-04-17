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

        [IgnoreFormat] public virtual IGameArchive Archive { get; set; }
        [IgnoreFormat] public virtual string CompressionType { get; set; }
        [IgnoreFormat] public virtual string Name { get; set; }

        /// <summary>
        /// !!! Double check when writing !!! Some files use 64bit, older files may use 32bit.
        /// </summary>
        [IgnoreFormat] public virtual long PageOffset { get; set; }

        /// <summary>
        /// Uncompressed asset size in bytes
        /// </summary>
        [IgnoreFormat] public virtual uint Size { get; set; }

        /// <summary>
        /// Compressed asset asize in bytes
        /// </summary>
        [IgnoreFormat] public virtual uint ZSize { get; set; }

        #endregion Properties

        #region Methods

        public virtual void Extract(Stream output)
        {
            // I guess its happy now....
        }

        #endregion Methods
    }
}
