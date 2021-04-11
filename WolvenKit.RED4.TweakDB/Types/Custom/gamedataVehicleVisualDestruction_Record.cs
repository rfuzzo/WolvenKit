namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleVisualDestruction_Record : gamedataTweakDBRecord
    {
        [RED("back")]
        public CFloat Back
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("backRight")]
        public CFloat BackRight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("left")]
        public CFloat Left
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("backLeft")]
        public CFloat BackLeft
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("frontLeft")]
        public CFloat FrontLeft
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("roof")]
        public CFloat Roof
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("right")]
        public CFloat Right
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("frontRight")]
        public CFloat FrontRight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("front")]
        public CFloat Front
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("setVisualDestruction")]
        public CBool SetVisualDestruction
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
