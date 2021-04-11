namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataEffector_Record : gamedataTweakDBRecord
    {
        [RED("animFeatureName")]
        public CName AnimFeatureName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("effectTypes")]
        public CArray<CString> EffectTypes
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("statPool")]
        public CString StatPool
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("vfxToStop")]
        public CName VfxToStop
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("sfxName")]
        public CName SfxName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("unitThreshold")]
        public CFloat UnitThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("increaseWithDistance")]
        public CBool IncreaseWithDistance
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("actionID")]
        public CString ActionID
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("comparePercentage")]
        public CBool ComparePercentage
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("amountOfPoints")]
        public CInt32 AmountOfPoints
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("appearanceName")]
        public CName AppearanceName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("dilation")]
        public CFloat Dilation
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("statusEffects")]
        public CArray<CString> StatusEffects
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("easeOutCurve")]
        public CName EaseOutCurve
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("blendInDuration")]
        public CFloat BlendInDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("vfxName")]
        public CName VfxName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("isRandom")]
        public CBool IsRandom
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("refObj")]
        public CString RefObj
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("amplitudeWeight")]
        public CFloat AmplitudeWeight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("poolStatus")]
        public CString PoolStatus
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("networkAction")]
        public CString NetworkAction
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("vfxToStart")]
        public CName VfxToStart
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("pointsType")]
        public CString PointsType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("easeInCurve")]
        public CName EaseInCurve
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("duration")]
        public CFloat Duration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("reward")]
        public CString Reward
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("probability")]
        public CFloat Probability
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("applyToOwner")]
        public CBool ApplyToOwner
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("deactivationSFXName")]
        public CName DeactivationSFXName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("sfxToStart")]
        public CName SfxToStart
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("applyToWeapon")]
        public CBool ApplyToWeapon
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("valueOff")]
        public CInt32 ValueOff
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("effectTag")]
        public CName EffectTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("sfxToStop")]
        public CName SfxToStop
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("primaryText")]
        public CString PrimaryText
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("hitFlag")]
        public CString HitFlag
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("fireAndForget")]
        public CBool FireAndForget
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("attackRecord")]
        public TweakDBID AttackRecord
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("weakSpotIndex")]
        public CInt32 WeakSpotIndex
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("fact")]
        public CName Fact
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("operationType")]
        public CString OperationType
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
        
        [RED("level")]
        public CFloat Level
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxDmg")]
        public CFloat MaxDmg
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("overrideMaterialName")]
        public CName OverrideMaterialName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("usePercent")]
        public CBool UsePercent
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("effectPath")]
        public CString EffectPath
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("applicationTarget")]
        public CString ApplicationTarget
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("valueOn")]
        public CInt32 ValueOn
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("percentMult")]
        public CFloat PercentMult
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("value")]
        public CFloat Value
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("startOnUninitialize")]
        public CBool StartOnUninitialize
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("attributeType")]
        public CString AttributeType
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
        
        [RED("blendOutDuration")]
        public CFloat BlendOutDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("overrideMaterialTag")]
        public CName OverrideMaterialTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("unique")]
        public CBool Unique
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("activationSFXName")]
        public CName ActivationSFXName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("secondaryText")]
        public CString SecondaryText
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("reason")]
        public CName Reason
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("resetAppearance")]
        public CBool ResetAppearance
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("prereqRecord")]
        public TweakDBID PrereqRecord
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("effectorClassName")]
        public CName EffectorClassName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("statPoolUpdates")]
        public CArray<TweakDBID> StatPoolUpdates
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("statModifierGroups")]
        public CArray<TweakDBID> StatModifierGroups
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("removeAfterActionCall")]
        public CBool RemoveAfterActionCall
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
