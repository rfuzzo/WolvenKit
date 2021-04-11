namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleDestructibleLight_Record : gamedataTweakDBRecord
    {
        [RED("threshold")]
        public CFloat Threshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("gridCells")]
        public CArray<CInt32> GridCells
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("component")]
        public CName Component
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
