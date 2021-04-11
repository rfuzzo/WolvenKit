namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataThreatTrackingPresetBase_Record : gamedataTweakDBRecord
    {
        [RED("moveBeliefOnlyIfVisible")]
        public CBool MoveBeliefOnlyIfVisible
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("baseDroppingThreatCooldown")]
        public CFloat BaseDroppingThreatCooldown
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("droppingCooldownPerSecondWhileVisible")]
        public CFloat DroppingCooldownPerSecondWhileVisible
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maximumDroppingCooldownValue")]
        public CFloat MaximumDroppingCooldownValue
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("visibleBeliefSpeedMultiplier")]
        public CFloat VisibleBeliefSpeedMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("droppingCooldownPerHit")]
        public CFloat DroppingCooldownPerHit
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("baseAccuracy")]
        public TweakDBID BaseAccuracy
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("beliefAccuracy")]
        public TweakDBID BeliefAccuracy
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
