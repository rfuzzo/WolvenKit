namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleUIData_Record : gamedataTweakDBRecord
    {
        [RED("driveLayout")]
        public CString DriveLayout
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("horsepower")]
        public CFloat Horsepower
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("mass")]
        public CFloat Mass
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("productionYear")]
        public CString ProductionYear
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("info")]
        public CString Info
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
