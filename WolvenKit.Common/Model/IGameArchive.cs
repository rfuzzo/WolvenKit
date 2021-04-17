using ZeroFormatter;

namespace WolvenKit.Common
{


    [ZeroFormattable]
    public abstract class IGameArchive
    {
        #region Properties

        [Index(0)] public virtual string ArchiveAbsolutePath { get; set; }
        [Index(1)] public virtual EArchiveType TypeName { get; set; }

        #endregion Properties
    }
}
