namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataUtilityLossCoverSelectionParameters_Record : gamedataCoverSelectionParameters_Record
    {
        [RED("hitsTakenToClearScoreShootingSpot")]
        public CInt32 HitsTakenToClearScoreShootingSpot
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("utilityLossTimeoutShootingSpot")]
        public CFloat UtilityLossTimeoutShootingSpot
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("utilityLossMultiplier")]
        public CFloat UtilityLossMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("hitsTakenToClearScoreCover")]
        public CInt32 HitsTakenToClearScoreCover
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("utilityLossTimeoutCover")]
        public CFloat UtilityLossTimeoutCover
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("hitsTakenToClearScoreInIdle")]
        public CInt32 HitsTakenToClearScoreInIdle
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("utilityLossTimeoutInIdle")]
        public CFloat UtilityLossTimeoutInIdle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
