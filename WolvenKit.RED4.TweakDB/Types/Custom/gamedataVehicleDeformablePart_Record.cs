namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleDeformablePart_Record : gamedataTweakDBRecord
    {
        [RED("component")]
        public CName Component
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("zones")]
        public CArray<TweakDBID> Zones
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
