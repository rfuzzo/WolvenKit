namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAttack_Melee_Record : gamedataTweakDBRecord
    {
        [RED("forcePlayerToStand")]
        public CBool ForcePlayerToStand
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("forwardImpulse")]
        public CFloat ForwardImpulse
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spawnDistance")]
        public CFloat SpawnDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("attackGameEffectDelay")]
        public CFloat AttackGameEffectDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("cooldown")]
        public CFloat Cooldown
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minimumDistanceToTargetToAddImpulse")]
        public CFloat MinimumDistanceToTargetToAddImpulse
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("duration")]
        public CFloat Duration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("recoverHitDuration")]
        public CFloat RecoverHitDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("adjustmentCurve")]
        public CName AdjustmentCurve
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("recoveryDuration")]
        public CFloat RecoveryDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("addedImpulseDelay")]
        public CFloat AddedImpulseDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("adjustmentRadius")]
        public CFloat AdjustmentRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("dontScaleWithAttackSpeed")]
        public CBool DontScaleWithAttackSpeed
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("upImpulse")]
        public CFloat UpImpulse
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("chargeCost")]
        public CFloat ChargeCost
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("standUpDelay")]
        public CFloat StandUpDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("enableAdjustingPlayerPositionToTarget")]
        public CBool EnableAdjustingPlayerPositionToTarget
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("blockTransitionTime")]
        public CFloat BlockTransitionTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("addedImpulse")]
        public CFloat AddedImpulse
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("adjustmentDistanceRadiusOffset")]
        public CFloat AdjustmentDistanceRadiusOffset
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("overrideHitReactionImpulse")]
        public CFloat OverrideHitReactionImpulse
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("ikOffset")]
        public Vector3 IkOffset
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("hasHitAnim")]
        public CBool HasHitAnim
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("activeHitDuration")]
        public CFloat ActiveHitDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("useAttackSlot")]
        public CBool UseAttackSlot
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("startupDuration")]
        public CFloat StartupDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("radius")]
        public CFloat Radius
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
        
        [RED("trailStopDelay")]
        public CFloat TrailStopDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("activeDuration")]
        public CFloat ActiveDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("disableAdjustingPlayerPositionToTarget")]
        public CBool DisableAdjustingPlayerPositionToTarget
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("attackEffectDelay")]
        public CFloat AttackEffectDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("adjustmentRange")]
        public CFloat AdjustmentRange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("trailAttackSide")]
        public CString TrailAttackSide
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("impulseDelay")]
        public CFloat ImpulseDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("impactFxSlot")]
        public CName ImpactFxSlot
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("useAdjustmentInsteadOfImpulse")]
        public CBool UseAdjustmentInsteadOfImpulse
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("attackEffectDuration")]
        public CFloat AttackEffectDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("attackWindowClosed")]
        public CFloat AttackWindowClosed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("adjustmentDuration")]
        public CFloat AdjustmentDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("cameraSpaceImpulse")]
        public CFloat CameraSpaceImpulse
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("incrementsCombo")]
        public CBool IncrementsCombo
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("attackRange")]
        public CFloat AttackRange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("enableMoveAssistOnLightAimAssist")]
        public CBool EnableMoveAssistOnLightAimAssist
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("attackWindowOpen")]
        public CFloat AttackWindowOpen
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("idleTransitionTime")]
        public CFloat IdleTransitionTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("trailStartDelay")]
        public CFloat TrailStartDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("attackGameEffectDuration")]
        public CFloat AttackGameEffectDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("shouldAdjust")]
        public CBool ShouldAdjust
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("recoverDuration")]
        public CFloat RecoverDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("hasDeflectAnim")]
        public CBool HasDeflectAnim
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
        
        [RED("hitFlags")]
        public CArray<CString> HitFlags
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("statusEffects")]
        public CArray<TweakDBID> StatusEffects
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("attackDirection")]
        public TweakDBID AttackDirection
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("playerIncomingDamageMultiplier")]
        public CFloat PlayerIncomingDamageMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("userDataPath")]
        public CString UserDataPath
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("attackName")]
        public CString AttackName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("useDefaultAimData")]
        public CBool UseDefaultAimData
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("attackSubtype")]
        public TweakDBID AttackSubtype
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("hitReactionSeverityMax")]
        public CInt32 HitReactionSeverityMax
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("blockCostFactor")]
        public CFloat BlockCostFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("effectTag")]
        public CName EffectTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("attackTag")]
        public CName AttackTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("hitReactionSeverityMin")]
        public CInt32 HitReactionSeverityMin
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("audioTag")]
        public CName AudioTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("range")]
        public CFloat Range
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("attackType")]
        public TweakDBID AttackType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("effectName")]
        public CName EffectName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("className")]
        public CName ClassName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("audioAttackIndex")]
        public CFloat AudioAttackIndex
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("damageType")]
        public TweakDBID DamageType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("staminaCost")]
        public CArray<TweakDBID> StaminaCost
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
