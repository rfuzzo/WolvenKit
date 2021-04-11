namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleDestructibleGlass_Record : gamedataTweakDBRecord
    {
        [RED("broken")]
        public CName Broken
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("effect")]
        public CName Effect
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("component")]
        public CName Component
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("isWindshield")]
        public CBool IsWindshield
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("gridCells")]
        public CArray<CInt32> GridCells
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("threshold")]
        public CFloat Threshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
