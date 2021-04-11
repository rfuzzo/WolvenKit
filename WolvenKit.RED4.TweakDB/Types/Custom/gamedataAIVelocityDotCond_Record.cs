namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIVelocityDotCond_Record : gamedataTweakDBRecord
    {
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("timePeriod")]
        public CFloat TimePeriod
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("positionTarget")]
        public TweakDBID PositionTarget
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("velocityTarget")]
        public TweakDBID VelocityTarget
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("dotRange")]
        public Vector2 DotRange
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
    }
}
