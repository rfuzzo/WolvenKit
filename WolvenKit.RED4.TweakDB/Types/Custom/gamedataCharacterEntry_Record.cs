namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCharacterEntry_Record : gamedataTweakDBRecord
    {
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("id")]
        public CInt32 Id
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
