namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleTPPCameraPresetParams_Record : gamedataTweakDBRecord
    {
        [RED("lookAtOffset")]
        public Vector3 LookAtOffset
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("airFlowDistortionSizeHorizontal")]
        public CFloat AirFlowDistortionSizeHorizontal
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("boomLength")]
        public CFloat BoomLength
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("distance")]
        public CName Distance
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("airFlowDistortionSizeVertical")]
        public CFloat AirFlowDistortionSizeVertical
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("airFlowDistortionSpeedMin")]
        public CFloat AirFlowDistortionSpeedMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("defaultRotationPitch")]
        public CFloat DefaultRotationPitch
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("height")]
        public CName Height
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("airFlowDistortionSpeedMax")]
        public CFloat AirFlowDistortionSpeedMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
