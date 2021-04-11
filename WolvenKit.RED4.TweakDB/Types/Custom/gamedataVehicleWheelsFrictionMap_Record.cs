namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleWheelsFrictionMap_Record : gamedataTweakDBRecord
    {
        [RED("surfaces")]
        public CArray<TweakDBID> Surfaces
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("defaultFrictionPreset")]
        public TweakDBID DefaultFrictionPreset
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
