namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionSetInfluenceMap_Record : gamedataTweakDBRecord
    {
        [RED("radius")]
        public CFloat Radius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("threat")]
        public CBool Threat
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
        
        [RED("lerp")]
        public Vector2 Lerp
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("positionObj")]
        public TweakDBID PositionObj
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
