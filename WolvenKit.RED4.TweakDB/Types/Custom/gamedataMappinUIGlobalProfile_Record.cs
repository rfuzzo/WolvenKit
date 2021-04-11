namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMappinUIGlobalProfile_Record : gamedataTweakDBRecord
    {
        [RED("verticalRelationTolerance")]
        public CFloat VerticalRelationTolerance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("verticalRelationVisibleRangeMax")]
        public CFloat VerticalRelationVisibleRangeMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("verticalRelationVisibleRangeMin")]
        public CFloat VerticalRelationVisibleRangeMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("nameplateVisibleInTier")]
        public CArray<CBool> NameplateVisibleInTier
        {
            get => GetProperty<CArray<CBool>>();
            set => SetProperty<CArray<CBool>>(value);
        }
        
        [RED("completedPOIOpacity")]
        public CFloat CompletedPOIOpacity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("gpsPortalIconScale")]
        public CFloat GpsPortalIconScale
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("nameplateVisibleInBraindance")]
        public CBool NameplateVisibleInBraindance
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
