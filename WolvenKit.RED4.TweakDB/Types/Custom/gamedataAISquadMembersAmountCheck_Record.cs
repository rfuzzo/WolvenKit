namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISquadMembersAmountCheck_Record : gamedataTweakDBRecord
    {
        [RED("maxAmount")]
        public CInt32 MaxAmount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("countSelf")]
        public CBool CountSelf
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("optionalFastExit")]
        public CBool OptionalFastExit
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("minAmount")]
        public CInt32 MinAmount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
