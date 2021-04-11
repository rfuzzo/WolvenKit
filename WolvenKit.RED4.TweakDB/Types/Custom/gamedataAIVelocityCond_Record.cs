namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIVelocityCond_Record : gamedataTweakDBRecord
    {
        [RED("timePeriod")]
        public CFloat TimePeriod
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("range")]
        public Vector2 Range
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
