namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataBuildPerk_Record : gamedataTweakDBRecord
    {
        [RED("perk")]
        public TweakDBID Perk
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("isActive")]
        public CBool IsActive
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("level")]
        public CInt32 Level
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
