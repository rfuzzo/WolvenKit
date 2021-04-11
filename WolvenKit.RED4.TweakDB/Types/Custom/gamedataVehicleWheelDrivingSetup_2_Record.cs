namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleWheelDrivingSetup_2_Record : gamedataTweakDBRecord
    {
        [RED("frontPreset")]
        public TweakDBID FrontPreset
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("F")]
        public TweakDBID F
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("B")]
        public TweakDBID B
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
