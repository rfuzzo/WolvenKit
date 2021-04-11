namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataReactionPreset_Record : gamedataTweakDBRecord
    {
        [RED("rules")]
        public CArray<TweakDBID> Rules
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("fearThreshold")]
        public CFloat FearThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("statModifiers")]
        public CArray<TweakDBID> StatModifiers
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("presetMapper")]
        public CArray<TweakDBID> PresetMapper
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("reactionGroup")]
        public CString ReactionGroup
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("enumComment")]
        public CString EnumComment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("aggressiveThreshold")]
        public CFloat AggressiveThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("isAggressive")]
        public CBool IsAggressive
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
