namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataGrenade_Record : gamedataGadget_Record
    {
        [RED("freezingDuration")]
        public CFloat FreezingDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("additionalAttackOnDetonate")]
        public CBool AdditionalAttackOnDetonate
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("addAxisRotationDelay")]
        public CFloat AddAxisRotationDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("effectCooldown")]
        public CFloat EffectCooldown
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("explodeOnImpact")]
        public CBool ExplodeOnImpact
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("isContinuousEffect")]
        public CBool IsContinuousEffect
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("stopAttackDelay")]
        public CFloat StopAttackDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("freezeDelayAfterBounce")]
        public CFloat FreezeDelayAfterBounce
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("delayToDetonate")]
        public CFloat DelayToDetonate
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("addAxisRotationSpeedMax")]
        public CFloat AddAxisRotationSpeedMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("addAxisRotationSpeedMin")]
        public CFloat AddAxisRotationSpeedMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("numberOfHitsForAdditionalAttack")]
        public CInt32 NumberOfHitsForAdditionalAttack
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("minimumDistanceFromFloor")]
        public CFloat MinimumDistanceFromFloor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("stickyTrackerTimeout")]
        public CFloat StickyTrackerTimeout
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("setStickyTracker")]
        public CBool SetStickyTracker
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("attackRadius")]
        public CFloat AttackRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("shootCollisionEnableDelay")]
        public CFloat ShootCollisionEnableDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("releaseOnDetonation")]
        public CBool ReleaseOnDetonation
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("detonationStimType")]
        public TweakDBID DetonationStimType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("attackDuration")]
        public CFloat AttackDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("detonationSound")]
        public CString DetonationSound
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("rotationAxesZ")]
        public CArray<CFloat> RotationAxesZ
        {
            get => GetProperty<CArray<CFloat>>();
            set => SetProperty<CArray<CFloat>>(value);
        }
        
        [RED("deliveryMethod")]
        public TweakDBID DeliveryMethod
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("randomRotationAxes")]
        public CInt32 RandomRotationAxes
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("npcHitReactionAttack")]
        public TweakDBID NpcHitReactionAttack
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("removeMeshOnDetonation")]
        public CBool RemoveMeshOnDetonation
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("seed")]
        public CInt32 Seed
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("rotationSpeedMin")]
        public CFloat RotationSpeedMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("rotationSpeedMax")]
        public CFloat RotationSpeedMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("rotationAxesX")]
        public CArray<CFloat> RotationAxesX
        {
            get => GetProperty<CArray<CFloat>>();
            set => SetProperty<CArray<CFloat>>(value);
        }
        
        [RED("detonationStimRadius")]
        public CFloat DetonationStimRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("enemyAttack")]
        public TweakDBID EnemyAttack
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("rotationAxesY")]
        public CArray<CFloat> RotationAxesY
        {
            get => GetProperty<CArray<CFloat>>();
            set => SetProperty<CArray<CFloat>>(value);
        }
        
        [RED("rotationAxesSpeeds")]
        public CArray<CFloat> RotationAxesSpeeds
        {
            get => GetProperty<CArray<CFloat>>();
            set => SetProperty<CArray<CFloat>>(value);
        }
        
        [RED("useSeed")]
        public CBool UseSeed
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("additionalAttack")]
        public TweakDBID AdditionalAttack
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("attack")]
        public TweakDBID Attack
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
