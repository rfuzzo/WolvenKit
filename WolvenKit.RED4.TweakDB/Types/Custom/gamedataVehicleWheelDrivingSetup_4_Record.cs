namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleWheelDrivingSetup_4_Record : gamedataTweakDBRecord
    {
        [RED("LB")]
        public TweakDBID LB
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("LF")]
        public TweakDBID LF
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
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
        
        [RED("RF")]
        public TweakDBID RF
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("RB")]
        public TweakDBID RB
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
