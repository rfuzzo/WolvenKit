namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleDetachablePart_Record : gamedataTweakDBRecord
    {
        [RED("spawnsExplosionEffect")]
        public CBool SpawnsExplosionEffect
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("components")]
        public CArray<CName> Components
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
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
        
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
