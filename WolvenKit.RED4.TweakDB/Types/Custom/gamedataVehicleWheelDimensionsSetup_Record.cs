namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleWheelDimensionsSetup_Record : gamedataTweakDBRecord
    {
        [RED("frontPreset")]
        public TweakDBID FrontPreset
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("backPreset")]
        public TweakDBID BackPreset
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
