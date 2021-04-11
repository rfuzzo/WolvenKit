namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIBlockCountCond_Record : gamedataTweakDBRecord
    {
        [RED("minParryCount")]
        public CInt32 MinParryCount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("ownerAttackParriedCount")]
        public CInt32 OwnerAttackParriedCount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("ownerAttackBlockedCount")]
        public CInt32 OwnerAttackBlockedCount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("maxParryCount")]
        public CInt32 MaxParryCount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("minBlockCount")]
        public CInt32 MinBlockCount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("maxBlockCount")]
        public CInt32 MaxBlockCount
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
    }
}
