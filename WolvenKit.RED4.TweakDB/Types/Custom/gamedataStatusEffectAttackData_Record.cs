namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataStatusEffectAttackData_Record : gamedataTweakDBRecord
    {
        [RED("applyImmediately")]
        public CBool ApplyImmediately
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("resistPool")]
        public TweakDBID ResistPool
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
        
        [RED("stacksToApply")]
        public CFloat StacksToApply
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
