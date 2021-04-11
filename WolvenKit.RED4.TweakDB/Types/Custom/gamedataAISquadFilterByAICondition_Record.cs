namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISquadFilterByAICondition_Record : gamedataTweakDBRecord
    {
        [RED("condition")]
        public TweakDBID Condition
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("skipSelfOnce")]
        public CBool SkipSelfOnce
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("resetMembersIncludingUnwillings")]
        public CBool ResetMembersIncludingUnwillings
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("resetMembers")]
        public CBool ResetMembers
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
