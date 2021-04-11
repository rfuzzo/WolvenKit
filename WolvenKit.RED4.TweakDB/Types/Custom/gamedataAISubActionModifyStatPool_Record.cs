namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionModifyStatPool_Record : gamedataTweakDBRecord
    {
        [RED("perc")]
        public CBool Perc
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("statPool")]
        public TweakDBID StatPool
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("amount")]
        public CFloat Amount
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
