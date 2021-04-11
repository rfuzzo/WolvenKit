namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionStatusEffect_Record : gamedataTweakDBRecord
    {
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("statusEffects")]
        public CArray<TweakDBID> StatusEffects
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("remove")]
        public CBool Remove
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("apply")]
        public CBool Apply
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
