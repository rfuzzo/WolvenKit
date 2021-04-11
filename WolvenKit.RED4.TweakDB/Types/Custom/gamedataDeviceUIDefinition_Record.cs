namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataDeviceUIDefinition_Record : gamedataTweakDBRecord
    {
        [RED("computerScreenType")]
        public TweakDBID ComputerScreenType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("terminalScreenType")]
        public TweakDBID TerminalScreenType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
