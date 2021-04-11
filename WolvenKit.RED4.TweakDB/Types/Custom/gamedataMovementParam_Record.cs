namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMovementParam_Record : gamedataTweakDBRecord
    {
        [RED("acceleration")]
        public CFloat Acceleration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("rotationSpeed")]
        public CFloat RotationSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("enumComment")]
        public CString EnumComment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("deceleration")]
        public CFloat Deceleration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxSpeed")]
        public CFloat MaxSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
