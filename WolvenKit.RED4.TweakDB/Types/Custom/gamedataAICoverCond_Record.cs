namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAICoverCond_Record : gamedataTweakDBRecord
    {
        [RED("checkChosenExposureMethod")]
        public CArray<CName> CheckChosenExposureMethod
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("desiredCoverChanged")]
        public CInt32 DesiredCoverChanged
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("isProtectingHorizontallyAgainstTarget")]
        public CInt32 IsProtectingHorizontallyAgainstTarget
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("checkIfCoverTransitionRequired")]
        public CBool CheckIfCoverTransitionRequired
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("maxCoverToTargetAngle")]
        public CFloat MaxCoverToTargetAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("isOwnerCrouching")]
        public CInt32 IsOwnerCrouching
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("minCoverHealth")]
        public CFloat MinCoverHealth
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("desiredCover")]
        public TweakDBID DesiredCover
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("coverExposureMethods")]
        public CArray<CName> CoverExposureMethods
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("predictionTime")]
        public CFloat PredictionTime
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
        
        [RED("cover")]
        public TweakDBID Cover
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("isOwnerExposed")]
        public CInt32 IsOwnerExposed
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("owner")]
        public TweakDBID Owner
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("coverType")]
        public CInt32 CoverType
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
