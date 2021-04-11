namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataNewsFeedTitle_Record : gamedataTweakDBRecord
    {
        [RED("titlesList")]
        public CArray<CName> TitlesList
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
    }
}
