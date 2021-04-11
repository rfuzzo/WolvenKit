namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataJournalIcon_Record : gamedataTweakDBRecord
    {
        [RED("atlasPartName")]
        public CName AtlasPartName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("atlasResourcePath")]
        public raRef<CResource> AtlasResourcePath
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
    }
}
