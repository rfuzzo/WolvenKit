namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataSceneCameraDoF_Record : gamedataTweakDBRecord
    {
        [RED("useFarPlane")]
        public CBool UseFarPlane
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("dofNearBlur")]
        public CFloat DofNearBlur
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("useNearPlane")]
        public CBool UseNearPlane
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("profileName")]
        public CName ProfileName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("dofFarFocus")]
        public CFloat DofFarFocus
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("dofFarBlur")]
        public CFloat DofFarBlur
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("dofIntensity")]
        public CFloat DofIntensity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("dofNearFocus")]
        public CFloat DofNearFocus
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
