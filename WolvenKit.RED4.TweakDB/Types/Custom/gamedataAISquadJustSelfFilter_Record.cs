namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISquadJustSelfFilter_Record : gamedataTweakDBRecord
    {
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
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
    }
}
