namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleSurfaceBinding_Record : gamedataTweakDBRecord
    {
        [RED("frictionPreset")]
        public TweakDBID FrictionPreset
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("surfaceType")]
        public TweakDBID SurfaceType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
