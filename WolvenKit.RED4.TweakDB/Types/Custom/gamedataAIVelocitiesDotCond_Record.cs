namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIVelocitiesDotCond_Record : gamedataTweakDBRecord
    {
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("secondTimePeriod")]
        public CFloat SecondTimePeriod
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("firstTimePeriod")]
        public CFloat FirstTimePeriod
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("dotRange")]
        public Vector2 DotRange
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("firstTarget")]
        public TweakDBID FirstTarget
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("secondTarget")]
        public TweakDBID SecondTarget
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
