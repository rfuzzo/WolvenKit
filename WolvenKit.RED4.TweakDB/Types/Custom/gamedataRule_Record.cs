namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRule_Record : gamedataTweakDBRecord
    {
        [RED("workspotOutput")]
        public CName WorkspotOutput
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("stimulus")]
        public TweakDBID Stimulus
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("output")]
        public TweakDBID Output
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("cooldown")]
        public CFloat Cooldown
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
