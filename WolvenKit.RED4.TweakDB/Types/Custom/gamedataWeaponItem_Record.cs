namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataWeaponItem_Record : gamedataItem_Record
    {
        [RED("scaleToPlayer")]
        public CBool ScaleToPlayer
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("saveStatPools")]
        public CBool SaveStatPools
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("baseEmptyReloadTime")]
        public CFloat BaseEmptyReloadTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("weaponNearPlane")]
        public CFloat WeaponNearPlane
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("weaponFarPlane")]
        public CFloat WeaponFarPlane
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("divideAttacksByPelletsOnUI")]
        public CBool DivideAttacksByPelletsOnUI
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("hide_nametag")]
        public CBool Hide_nametag
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("weaponFarPlane_aim")]
        public CFloat WeaponFarPlane_aim
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("weaponVignetteIntensity")]
        public CFloat WeaponVignetteIntensity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("weaponBlurIntensity_aim")]
        public CFloat WeaponBlurIntensity_aim
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("baseReloadTime")]
        public CFloat BaseReloadTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("offset")]
        public CFloat Offset
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("weaponVignetteIntensity_aim")]
        public CFloat WeaponVignetteIntensity_aim
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("weaponEdgesSharpness_aim")]
        public CFloat WeaponEdgesSharpness_aim
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("specific_player_appearance")]
        public CName Specific_player_appearance
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("weaponVignetteRadius_aim")]
        public CFloat WeaponVignetteRadius_aim
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("uninterruptibleReloadStart")]
        public CFloat UninterruptibleReloadStart
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("uninterruptibleEmptyReloadStart")]
        public CFloat UninterruptibleEmptyReloadStart
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("weaponVignetteCircular")]
        public CFloat WeaponVignetteCircular
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("weaponBlurIntensity")]
        public CFloat WeaponBlurIntensity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("weaponEdgesSharpness")]
        public CFloat WeaponEdgesSharpness
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
        
        [RED("weaponVignetteRadius")]
        public CFloat WeaponVignetteRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("safeActionDuration")]
        public CFloat SafeActionDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("position")]
        public Vector3 Position
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("price")]
        public TweakDBID Price
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("ironsightAngleWithScope")]
        public CFloat IronsightAngleWithScope
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("projectileTemplateName")]
        public CName ProjectileTemplateName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("weaponNearPlane_aim")]
        public CFloat WeaponNearPlane_aim
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("IsIKEnabled")]
        public CBool IsIKEnabled
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("weaponVignetteCircular_aim")]
        public CFloat WeaponVignetteCircular_aim
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("attacks")]
        public CArray<TweakDBID> Attacks
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("manufacturer")]
        public TweakDBID Manufacturer
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("ammo")]
        public TweakDBID Ammo
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("audioWeaponConfiguration")]
        public CName AudioWeaponConfiguration
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("rangedAttacks")]
        public TweakDBID RangedAttacks
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("previewEffectName")]
        public CName PreviewEffectName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("effectiveRangeFalloffCurve")]
        public CName EffectiveRangeFalloffCurve
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("hudIcon")]
        public TweakDBID HudIcon
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("damageType")]
        public TweakDBID DamageType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("primaryTriggerMode")]
        public TweakDBID PrimaryTriggerMode
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("holsteredItem")]
        public TweakDBID HolsteredItem
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("previewEffectTag")]
        public CName PreviewEffectTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("shootingPatternPackages")]
        public CArray<TweakDBID> ShootingPatternPackages
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("evolution")]
        public TweakDBID Evolution
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("projectileEaseOutCurveName")]
        public CName ProjectileEaseOutCurveName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("fxPackageQuickMelee")]
        public TweakDBID FxPackageQuickMelee
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("secondaryTriggerMode")]
        public TweakDBID SecondaryTriggerMode
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("fxPackage")]
        public TweakDBID FxPackage
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("NPCAnimWrapperWeightOverride")]
        public CName NPCAnimWrapperWeightOverride
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("effectiveRangeCurve")]
        public CName EffectiveRangeCurve
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("triggerModes")]
        public CArray<TweakDBID> TriggerModes
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("useForcedTBHZOffset")]
        public CBool UseForcedTBHZOffset
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("forcedMinHitReaction")]
        public CInt32 ForcedMinHitReaction
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
