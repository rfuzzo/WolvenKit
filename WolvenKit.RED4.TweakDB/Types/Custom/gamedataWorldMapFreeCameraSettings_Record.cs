namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataWorldMapFreeCameraSettings_Record : gamedataTweakDBRecord
    {
        [RED("rotationSpeed")]
        public EulerAngles RotationSpeed
        {
            get => GetProperty<EulerAngles>();
            set => SetProperty<EulerAngles>(value);
        }
        
        [RED("rotationDefault")]
        public EulerAngles RotationDefault
        {
            get => GetProperty<EulerAngles>();
            set => SetProperty<EulerAngles>(value);
        }
        
        [RED("zoomMax")]
        public CFloat ZoomMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("zoomMin")]
        public CFloat ZoomMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("zoomDefault")]
        public CFloat ZoomDefault
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("pitchRelativeToZoom")]
        public CBool PitchRelativeToZoom
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("mouseZoomSpeedMin")]
        public CFloat MouseZoomSpeedMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("mouseZoomSpeedMax")]
        public CFloat MouseZoomSpeedMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("mouseRotateStrength")]
        public CFloat MouseRotateStrength
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("iconScaleMin")]
        public CFloat IconScaleMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("zoomSpeedMax")]
        public CFloat ZoomSpeedMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("zoomSpeed")]
        public CFloat ZoomSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("zoomDefaultInFastTravel")]
        public CFloat ZoomDefaultInFastTravel
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("fovMax")]
        public CFloat FovMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("fovMin")]
        public CFloat FovMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("zoomSpeedMin")]
        public CFloat ZoomSpeedMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("iconScaleMax")]
        public CFloat IconScaleMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("panSpeedMin")]
        public CFloat PanSpeedMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("rotationMin")]
        public EulerAngles RotationMin
        {
            get => GetProperty<EulerAngles>();
            set => SetProperty<EulerAngles>(value);
        }
        
        [RED("rotationMax")]
        public EulerAngles RotationMax
        {
            get => GetProperty<EulerAngles>();
            set => SetProperty<EulerAngles>(value);
        }
        
        [RED("mousePanStrength")]
        public CFloat MousePanStrength
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("panSpeedMax")]
        public CFloat PanSpeedMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
