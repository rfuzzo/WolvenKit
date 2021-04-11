namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionConditionalFailure_Record : gamedataTweakDBRecord
    {
        [RED("condition")]
        public CArray<TweakDBID> Condition
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("cooldowns")]
        public CArray<TweakDBID> Cooldowns
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
