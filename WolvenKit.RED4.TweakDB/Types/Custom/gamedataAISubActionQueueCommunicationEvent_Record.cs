namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionQueueCommunicationEvent_Record : gamedataTweakDBRecord
    {
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("targetListener")]
        public TweakDBID TargetListener
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
