namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataObjectActionEffect_Record : gamedataTweakDBRecord
    {
        [RED("effectorToTrigger")]
        public TweakDBID EffectorToTrigger
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("recipient")]
        public TweakDBID Recipient
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("statusEffect")]
        public TweakDBID StatusEffect
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
