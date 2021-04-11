namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataGameplayRestrictionStatusEffect_Record : gamedataTweakDBRecord
    {
        [RED("restrictionName")]
        public CName RestrictionName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("savable")]
        public CBool Savable
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("gameplayTags")]
        public CArray<CName> GameplayTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("statusEffectType")]
        public TweakDBID StatusEffectType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("removeAllStacksWhenDurationEndsStatModifiers")]
        public TweakDBID RemoveAllStacksWhenDurationEndsStatModifiers
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("SFX")]
        public CArray<TweakDBID> SFX
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("VFX")]
        public CArray<TweakDBID> VFX
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("actionRestriction")]
        public TweakDBID ActionRestriction
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("isAffectedByTimeDilationPlayer")]
        public CBool IsAffectedByTimeDilationPlayer
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("isAffectedByTimeDilationNPC")]
        public CBool IsAffectedByTimeDilationNPC
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("replicated")]
        public CBool Replicated
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("duration")]
        public TweakDBID Duration
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("packages")]
        public CArray<TweakDBID> Packages
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("AIData")]
        public TweakDBID AIData
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("maxStacks")]
        public TweakDBID MaxStacks
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("immunityStats")]
        public CArray<TweakDBID> ImmunityStats
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("stopActiveSfxOnDeactivate")]
        public CBool StopActiveSfxOnDeactivate
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("debugTags")]
        public CArray<CName> DebugTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("playerData")]
        public TweakDBID PlayerData
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("removeOnStoryTier")]
        public CBool RemoveOnStoryTier
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("removeAllStacksWhenDurationEnds")]
        public CBool RemoveAllStacksWhenDurationEnds
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("uiData")]
        public TweakDBID UiData
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("additionalParam")]
        public CName AdditionalParam
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
