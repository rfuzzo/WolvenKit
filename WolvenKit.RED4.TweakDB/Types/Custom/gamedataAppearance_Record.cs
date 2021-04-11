namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAppearance_Record : gamedataTweakDBRecord
    {
        [RED("tags")]
        public CArray<CName> Tags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
    }
}
