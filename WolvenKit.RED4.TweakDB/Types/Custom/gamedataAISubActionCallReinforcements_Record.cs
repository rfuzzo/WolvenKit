namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionCallReinforcements_Record : gamedataTweakDBRecord
    {
        [RED("duration")]
        public CFloat Duration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
