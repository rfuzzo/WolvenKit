namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleDestructibleWheel_Record : gamedataTweakDBRecord
    {
        [RED("intact")]
        public CName Intact
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("flat")]
        public CName Flat
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
