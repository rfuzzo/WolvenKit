namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAttack_Projectile_Record : gamedataTweakDBRecord
    {
        [RED("p1PositionForwardOffsetMin")]
        public CFloat P1PositionForwardOffsetMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("puppetBroadphaseHitRadiusSquared")]
        public CFloat PuppetBroadphaseHitRadiusSquared
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("p1BendTimeRatio")]
        public CFloat P1BendTimeRatio
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("p1BendFactor")]
        public CFloat P1BendFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("p1AngleInVerticalPlane")]
        public CFloat P1AngleInVerticalPlane
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("targetPositionXYAdditive")]
        public CFloat TargetPositionXYAdditive
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("targetPositionOffset")]
        public CFloat TargetPositionOffset
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("p2AngleInHitPlaneMin")]
        public CFloat P2AngleInHitPlaneMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("explosionAttack")]
        public CName ExplosionAttack
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("p2AngleInVerticalPlane")]
        public CFloat P2AngleInVerticalPlane
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("p1SnapRadius")]
        public CFloat P1SnapRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("p1PositionForwardOffsetMax")]
        public CFloat P1PositionForwardOffsetMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("p2BendRation")]
        public CFloat P2BendRation
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("p2AngleInHitPlaneMax")]
        public CFloat P2AngleInHitPlaneMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("p1PositionZOffset")]
        public CFloat P1PositionZOffset
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("p1DurationMin")]
        public CFloat P1DurationMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("p1AngleInHitPlaneMax")]
        public CFloat P1AngleInHitPlaneMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("finalTargetPositionCalculationDelay")]
        public CFloat FinalTargetPositionCalculationDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("followTargetInPhase2")]
        public CBool FollowTargetInPhase2
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("p2StartVelocity")]
        public CFloat P2StartVelocity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("p1StartVelocity")]
        public CFloat P1StartVelocity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("p1AngleInHitPlaneMin")]
        public CFloat P1AngleInHitPlaneMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("p2ShouldRotate")]
        public CBool P2ShouldRotate
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("p2BendFactor")]
        public CFloat P2BendFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("playerPositionGrabTime")]
        public CFloat PlayerPositionGrabTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("p1PositionLateralOffset")]
        public CFloat P1PositionLateralOffset
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("p1DurationMax")]
        public CFloat P1DurationMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("hitCooldown")]
        public CFloat HitCooldown
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("explosionRadius")]
        public CFloat ExplosionRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("range")]
        public CFloat Range
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("hitReactionSeverityMin")]
        public CInt32 HitReactionSeverityMin
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("statusEffects")]
        public CArray<TweakDBID> StatusEffects
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("className")]
        public CName ClassName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("statModifiers")]
        public CArray<TweakDBID> StatModifiers
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("hitReactionSeverityMax")]
        public CInt32 HitReactionSeverityMax
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("userDataPath")]
        public CString UserDataPath
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("damageType")]
        public TweakDBID DamageType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("hitFlags")]
        public CArray<CString> HitFlags
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("projectileTemplateName")]
        public CName ProjectileTemplateName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("attackType")]
        public TweakDBID AttackType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("attackName")]
        public CString AttackName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("playerIncomingDamageMultiplier")]
        public CFloat PlayerIncomingDamageMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("useDefaultAimData")]
        public CBool UseDefaultAimData
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
