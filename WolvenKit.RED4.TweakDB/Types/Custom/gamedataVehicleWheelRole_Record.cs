namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleWheelRole_Record : gamedataTweakDBRecord
    {
        [RED("isDrive")]
        public CBool IsDrive
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("isMainBrake")]
        public CBool IsMainBrake
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("isHandBrake")]
        public CBool IsHandBrake
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
