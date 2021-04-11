namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionApplyTimeDilation_Record : gamedataTweakDBRecord
    {
        [RED("easeOut")]
        public CName EaseOut
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("duration")]
        public CFloat Duration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("easeIn")]
        public CName EaseIn
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("type")]
        public CName Type
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("overrideMultiplerWhenPlayerInTimeDilation")]
        public CFloat OverrideMultiplerWhenPlayerInTimeDilation
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("multiplier")]
        public CFloat Multiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
