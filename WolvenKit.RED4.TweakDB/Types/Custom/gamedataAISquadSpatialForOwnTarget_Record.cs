namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISquadSpatialForOwnTarget_Record : gamedataTweakDBRecord
    {
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
        
        [RED("spatial")]
        public TweakDBID Spatial
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
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
    }
}
