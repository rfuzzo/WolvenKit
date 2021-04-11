namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionChangeCoverSelectionPreset_Record : gamedataTweakDBRecord
    {
        [RED("fallbackToLastSelectedPreset")]
        public CBool FallbackToLastSelectedPreset
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("coverDisablingDuration")]
        public CFloat CoverDisablingDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("initialPreset")]
        public CName InitialPreset
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("gatheringObjectCenter")]
        public TweakDBID GatheringObjectCenter
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("preset")]
        public CName Preset
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("changeThreshold")]
        public CFloat ChangeThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
