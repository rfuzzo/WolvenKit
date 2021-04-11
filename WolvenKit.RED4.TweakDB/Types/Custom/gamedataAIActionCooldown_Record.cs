namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIActionCooldown_Record : gamedataTweakDBRecord
    {
        [RED("name")]
        public CName Name
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
        
        [RED("activationCondition")]
        public CArray<TweakDBID> ActivationCondition
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
