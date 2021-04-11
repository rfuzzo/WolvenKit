namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionChangeAttitude_Record : gamedataTweakDBRecord
    {
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("attitude")]
        public CName Attitude
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
