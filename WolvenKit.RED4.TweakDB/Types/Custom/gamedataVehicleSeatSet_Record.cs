namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleSeatSet_Record : gamedataTweakDBRecord
    {
        [RED("vehSeats")]
        public CArray<TweakDBID> VehSeats
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
