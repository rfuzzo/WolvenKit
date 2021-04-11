namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIReactionCond_Record : gamedataTweakDBRecord
    {
        [RED("validStimPosition")]
        public CBool ValidStimPosition
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("preset")]
        public TweakDBID Preset
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("investigateController")]
        public CBool InvestigateController
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("reactionBehaviorName")]
        public CName ReactionBehaviorName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("stimType")]
        public CArray<TweakDBID> StimType
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("thresholdValue")]
        public TweakDBID ThresholdValue
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
