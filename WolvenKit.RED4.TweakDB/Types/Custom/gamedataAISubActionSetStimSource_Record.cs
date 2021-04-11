namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionSetStimSource_Record : gamedataTweakDBRecord
    {
        [RED("useInvestigateData")]
        public CBool UseInvestigateData
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("stimTarget")]
        public TweakDBID StimTarget
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
    }
}
