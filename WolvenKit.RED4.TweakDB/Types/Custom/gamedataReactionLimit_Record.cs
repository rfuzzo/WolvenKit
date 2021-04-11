namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataReactionLimit_Record : gamedataTweakDBRecord
    {
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("limit")]
        public CInt32 Limit
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
