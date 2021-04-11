namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIActionLookAtData_Record : gamedataTweakDBRecord
    {
        [RED("preset")]
        public TweakDBID Preset
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("timeDelay")]
        public CFloat TimeDelay
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
        
        [RED("offset")]
        public Vector3 Offset
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("activationCondition")]
        public TweakDBID ActivationCondition
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
