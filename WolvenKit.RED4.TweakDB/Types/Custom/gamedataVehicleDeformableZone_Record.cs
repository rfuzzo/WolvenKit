namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleDeformableZone_Record : gamedataTweakDBRecord
    {
        [RED("shapes")]
        public CArray<CInt32> Shapes
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("gridCells")]
        public CArray<CInt32> GridCells
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
    }
}
