namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleSeat_Record : gamedataTweakDBRecord
    {
        [RED("seatName")]
        public CName SeatName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
