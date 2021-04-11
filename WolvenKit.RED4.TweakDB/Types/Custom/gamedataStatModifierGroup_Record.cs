namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataStatModifierGroup_Record : gamedataTweakDBRecord
    {
        [RED("drawBasedOnStatType")]
        public CBool DrawBasedOnStatType
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("statModifiers")]
        public CArray<TweakDBID> StatModifiers
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("statModsLimit")]
        public CInt32 StatModsLimit
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("statModsLimitModifier")]
        public TweakDBID StatModsLimitModifier
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
