namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPreventionHeatData_Record : gamedataTweakDBRecord
    {
        [RED("unitsCount")]
        public CInt32 UnitsCount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("spawnInterval")]
        public CFloat SpawnInterval
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spawnRange")]
        public Vector2 SpawnRange
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("unitRecordsPool")]
        public CArray<TweakDBID> UnitRecordsPool
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("vehicleRecord")]
        public TweakDBID VehicleRecord
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
