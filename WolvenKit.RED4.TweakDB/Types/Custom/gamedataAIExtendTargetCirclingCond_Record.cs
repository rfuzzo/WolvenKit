namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIExtendTargetCirclingCond_Record : gamedataTweakDBRecord
    {
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("spreadIncreaseAngle")]
        public CFloat SpreadIncreaseAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("destinationTarget")]
        public TweakDBID DestinationTarget
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
