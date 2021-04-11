namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataInteractionMountBase_Record : gamedataInteractionBase_Record
    {
        [RED("vehicleMountSlot")]
        public CName VehicleMountSlot
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("tag")]
        public CName Tag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
