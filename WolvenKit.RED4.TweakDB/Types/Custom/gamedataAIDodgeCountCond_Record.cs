namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIDodgeCountCond_Record : gamedataTweakDBRecord
    {
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("minDodgeCount")]
        public CInt32 MinDodgeCount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("OwnerAttackDodgedCount")]
        public CInt32 OwnerAttackDodgedCount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("maxDodgeCount")]
        public CInt32 MaxDodgeCount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
