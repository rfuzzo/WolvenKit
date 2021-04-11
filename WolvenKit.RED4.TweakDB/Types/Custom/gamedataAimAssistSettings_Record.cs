namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAimAssistSettings_Record : gamedataTweakDBRecord
    {
        [RED("off")]
        public TweakDBID Off
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("light")]
        public TweakDBID Light
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("standard")]
        public TweakDBID Standard
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
