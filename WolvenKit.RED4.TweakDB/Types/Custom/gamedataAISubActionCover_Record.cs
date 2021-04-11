namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionCover_Record : gamedataTweakDBRecord
    {
        [RED("clearLOSDistanceTolerance")]
        public CFloat ClearLOSDistanceTolerance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("setInitialCoverData")]
        public CBool SetInitialCoverData
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("insideCoverReselectionCooldown")]
        public TweakDBID InsideCoverReselectionCooldown
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("commandCoverConditions")]
        public CArray<TweakDBID> CommandCoverConditions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("setCurrentCover")]
        public CBool SetCurrentCover
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("setCoverExposureAnim")]
        public CBool SetCoverExposureAnim
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("coverExposureMethods")]
        public CArray<CName> CoverExposureMethods
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("exposedInCover")]
        public CInt32 ExposedInCover
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("setDesiredCover")]
        public CInt32 SetDesiredCover
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("exposureMethodPriority")]
        public CArray<TweakDBID> ExposureMethodPriority
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("prioritizeBlindFireAfterHit")]
        public CFloat PrioritizeBlindFireAfterHit
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
