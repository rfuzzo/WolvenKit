namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataIPrereq_Record : gamedataTweakDBRecord
    {
        [RED("tier")]
        public CInt32 Tier
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("pipelineStage")]
        public CString PipelineStage
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("isPlayerNoticed")]
        public CBool IsPlayerNoticed
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("isChoiceHubActive")]
        public CBool IsChoiceHubActive
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("object")]
        public CString Object
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("isSynchronous")]
        public CBool IsSynchronous
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("visualTag")]
        public CString VisualTag
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("attackType")]
        public CString AttackType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("reactionPreset")]
        public CString ReactionPreset
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("isBreached")]
        public CBool IsBreached
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("skipWhenApplied")]
        public CBool SkipWhenApplied
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("ammoState")]
        public CString AmmoState
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("statusEffect")]
        public CString StatusEffect
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("rarity")]
        public CString Rarity
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("itemTag")]
        public CString ItemTag
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("attackSubtype")]
        public CString AttackSubtype
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("dotType")]
        public CString DotType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("checkType")]
        public CString CheckType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("maxTime")]
        public CFloat MaxTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("inverted")]
        public CBool Inverted
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("failureExplanation")]
        public CString FailureExplanation
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("locomotionType")]
        public CString LocomotionType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("isMoving")]
        public CBool IsMoving
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("hasTag")]
        public CBool HasTag
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("attachmentSlot")]
        public CString AttachmentSlot
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("characterRecord")]
        public CString CharacterRecord
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("hitSource")]
        public CString HitSource
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("weaponEvolution")]
        public CString WeaponEvolution
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("fact")]
        public CName Fact
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("slotname")]
        public CName Slotname
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("itemType")]
        public CString ItemType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("randRange")]
        public CFloat RandRange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("setChance")]
        public CFloat SetChance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("percentage")]
        public CFloat Percentage
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("checkForRMA")]
        public CBool CheckForRMA
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("isInState")]
        public CBool IsInState
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("duration")]
        public CFloat Duration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minTime")]
        public CFloat MinTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("attitude")]
        public CString Attitude
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("callbackType")]
        public CString CallbackType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("isCheckInverted")]
        public CBool IsCheckInverted
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("hitReactionType")]
        public CString HitReactionType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("hitFlag")]
        public CString HitFlag
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("previousState")]
        public CBool PreviousState
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("comparisonType")]
        public CName ComparisonType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("itemCategory")]
        public CString ItemCategory
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("stateName")]
        public CString StateName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("visionModeType")]
        public CName VisionModeType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("perk")]
        public CString Perk
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("value")]
        public CInt32 Value
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("prereqClassName")]
        public CName PrereqClassName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
