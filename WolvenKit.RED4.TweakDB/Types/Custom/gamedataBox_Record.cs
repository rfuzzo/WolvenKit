namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataBox_Record : gamedataTweakDBRecord
    {
        [RED("detectionMultiplier")]
        public CFloat DetectionMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("max")]
        public Vector3 Max
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("min")]
        public Vector3 Min
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
    }
}
