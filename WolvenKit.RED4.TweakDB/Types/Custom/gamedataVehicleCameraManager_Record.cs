namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleCameraManager_Record : gamedataTweakDBRecord
    {
        [RED("camCollisionOBBIncrease")]
        public Vector3 CamCollisionOBBIncrease
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("cameraBlendTime")]
        public CFloat CameraBlendTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("allowCameraReset")]
        public CBool AllowCameraReset
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
