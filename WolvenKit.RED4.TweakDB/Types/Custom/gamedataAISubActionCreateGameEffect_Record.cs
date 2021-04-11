namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionCreateGameEffect_Record : gamedataTweakDBRecord
    {
        [RED("range")]
        public CFloat Range
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
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
        
        [RED("duration")]
        public CFloat Duration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("positionObj")]
        public TweakDBID PositionObj
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("effectName")]
        public CName EffectName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("rotationObj")]
        public TweakDBID RotationObj
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("colliderBoxSize")]
        public Vector3 ColliderBoxSize
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("targetPositionObj")]
        public TweakDBID TargetPositionObj
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("effectTag")]
        public CName EffectTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
