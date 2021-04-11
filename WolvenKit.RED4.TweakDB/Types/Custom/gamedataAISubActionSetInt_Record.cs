namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionSetInt_Record : gamedataTweakDBRecord
    {
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("value")]
        public CInt32 Value
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
