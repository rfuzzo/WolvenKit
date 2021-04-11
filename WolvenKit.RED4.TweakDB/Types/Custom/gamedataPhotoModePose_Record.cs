namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPhotoModePose_Record : gamedataTweakDBRecord
    {
        [RED("poseStateConfig")]
        public CName PoseStateConfig
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("positionOffset")]
        public Vector3 PositionOffset
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("poseSize")]
        public CFloat PoseSize
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("category")]
        public CName Category
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("filterOutForGarmentTags")]
        public CArray<CName> FilterOutForGarmentTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("animationName")]
        public CName AnimationName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("disableLookAtForGarmentTags")]
        public CArray<CName> DisableLookAtForGarmentTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("locked")]
        public CBool Locked
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("lookAtPreset")]
        public CName LookAtPreset
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("acceptedWeaponConfig")]
        public CName AcceptedWeaponConfig
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("displayName")]
        public CName DisplayName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
