using ZeroFormatter;

namespace WolvenKit.Common
{


    [ZeroFormattable]
    public abstract class IGameArchive
    {
        #region Properties

        [IgnoreFormat] public virtual string ArchiveAbsolutePath { get; set; }
        [IgnoreFormat] public virtual EArchiveType TypeName { get; set; }

        #endregion Properties
    }
}
