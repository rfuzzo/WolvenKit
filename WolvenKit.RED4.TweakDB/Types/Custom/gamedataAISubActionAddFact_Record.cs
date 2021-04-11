namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionAddFact_Record : gamedataTweakDBRecord
    {
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("resetValue")]
        public CBool ResetValue
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
