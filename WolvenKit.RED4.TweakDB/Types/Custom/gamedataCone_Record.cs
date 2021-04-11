namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCone_Record : gamedataTweakDBRecord
    {
        [RED("radius1")]
        public CFloat Radius1
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("position1")]
        public Vector3 Position1
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("detectionMultiplier")]
        public CFloat DetectionMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("radius2")]
        public CFloat Radius2
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("position2")]
        public Vector3 Position2
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
    }
}
