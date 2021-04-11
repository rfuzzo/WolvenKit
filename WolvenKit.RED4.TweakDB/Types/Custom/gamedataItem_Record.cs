namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataItem_Record : gamedataTweakDBRecord
    {
        [RED("rampUpDistanceEnd")]
        public CFloat RampUpDistanceEnd
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("canTargetVehicles")]
        public CBool CanTargetVehicles
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("projectileTemplateName")]
        public CName ProjectileTemplateName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("collisionActionCharged")]
        public CName CollisionActionCharged
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("startVelocity")]
        public CFloat StartVelocity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("despawnOnCollision")]
        public CBool DespawnOnCollision
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("price")]
        public TweakDBID Price
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("angle")]
        public CFloat Angle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("onCollisionStimType")]
        public CName OnCollisionStimType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("lifetime")]
        public CFloat Lifetime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("interpolationTimeRatio")]
        public CFloat InterpolationTimeRatio
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("onCollisionStimBroadcastLifetime")]
        public CFloat OnCollisionStimBroadcastLifetime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("angleInterpolationDuration")]
        public CFloat AngleInterpolationDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("detonationDelay")]
        public CFloat DetonationDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("rampUpDistanceStart")]
        public CFloat RampUpDistanceStart
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("canTargetDevices")]
        public CBool CanTargetDevices
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("maxBounceCount")]
        public CInt32 MaxBounceCount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("attack")]
        public CString Attack
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("halfLeanAngle")]
        public CFloat HalfLeanAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("rampDownDistanceStart")]
        public CFloat RampDownDistanceStart
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("secondaryAttack")]
        public CString SecondaryAttack
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("bendFactor")]
        public CFloat BendFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("returnTimeMargin")]
        public CFloat ReturnTimeMargin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("chargeActionlaunchMode")]
        public CName ChargeActionlaunchMode
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("hideCooldownUI")]
        public CBool HideCooldownUI
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("quickActionlaunchMode")]
        public CName QuickActionlaunchMode
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("randomizeDirection")]
        public CBool RandomizeDirection
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("isIKEnabled")]
        public CBool IsIKEnabled
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("applyAdditiveProjectileSpiraling")]
        public CBool ApplyAdditiveProjectileSpiraling
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("bendTimeRatio")]
        public CFloat BendTimeRatio
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("hideMeshOnCollision")]
        public CBool HideMeshOnCollision
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("onCollisionSound")]
        public CName OnCollisionSound
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("launchTrajectory")]
        public CName LaunchTrajectory
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("shootCollisionEnableDelay")]
        public CFloat ShootCollisionEnableDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("endLeanAngle")]
        public CFloat EndLeanAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("canStopAndStickOnHardSurfaces")]
        public CBool CanStopAndStickOnHardSurfaces
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("hideDurationUI")]
        public CBool HideDurationUI
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("linearTimeRatio")]
        public CFloat LinearTimeRatio
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("rampDownDistanceEnd")]
        public CFloat RampDownDistanceEnd
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("shardType")]
        public CName ShardType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("randomizePhase")]
        public CBool RandomizePhase
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("onCollisionStimBroadcastRadius")]
        public CFloat OnCollisionStimBroadcastRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("energyLossFactor")]
        public CFloat EnergyLossFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("cyberwareType")]
        public CName CyberwareType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("startVelocityCharged")]
        public CFloat StartVelocityCharged
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("collisionAction")]
        public CName CollisionAction
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("rampDownFactor")]
        public CFloat RampDownFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("gravitySimulation")]
        public Vector3 GravitySimulation
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("equipPrereqs")]
        public CArray<TweakDBID> EquipPrereqs
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("connections")]
        public CArray<TweakDBID> Connections
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("equipAreas")]
        public CArray<TweakDBID> EquipAreas
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("itemType")]
        public TweakDBID ItemType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("animSetResource")]
        public raRef<CResource> AnimSetResource
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("appearanceSuffixesOwnerOverride")]
        public CArray<CBool> AppearanceSuffixesOwnerOverride
        {
            get => GetProperty<CArray<CBool>>();
            set => SetProperty<CArray<CBool>>(value);
        }
        
        [RED("localizedDescription")]
        public gamedataLocKeyWrapper LocalizedDescription
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("objectActions")]
        public CArray<TweakDBID> ObjectActions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("buyPrice")]
        public CArray<TweakDBID> BuyPrice
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("friendlyName")]
        public CString FriendlyName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("sellPrice")]
        public CArray<TweakDBID> SellPrice
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("garmentOffset")]
        public CInt32 GarmentOffset
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("hairSkinnedMeshComponents")]
        public CArray<CName> HairSkinnedMeshComponents
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("gameplayRestrictions")]
        public CArray<TweakDBID> GameplayRestrictions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("audioSwitchName")]
        public CName AudioSwitchName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("entityName")]
        public CName EntityName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("appearanceName")]
        public CName AppearanceName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("statModifierGroups")]
        public CArray<TweakDBID> StatModifierGroups
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("placementSlots")]
        public CArray<TweakDBID> PlacementSlots
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("blueprint")]
        public TweakDBID Blueprint
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("animFeatureName")]
        public CName AnimFeatureName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("quality")]
        public TweakDBID Quality
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("parts")]
        public CArray<TweakDBID> Parts
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("stateMachineName")]
        public CName StateMachineName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("cameraUp")]
        public Vector3 CameraUp
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("CraftingData")]
        public TweakDBID CraftingData
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("npcRPGData")]
        public TweakDBID NpcRPGData
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("slotPartListPreset")]
        public CArray<TweakDBID> SlotPartListPreset
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("itemCategory")]
        public TweakDBID ItemCategory
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("requiredSlots")]
        public CArray<TweakDBID> RequiredSlots
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("effectors")]
        public CArray<TweakDBID> Effectors
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("attachmentSlots")]
        public CArray<TweakDBID> AttachmentSlots
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("cameraForward")]
        public Vector3 CameraForward
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("useNewSpawnMethod")]
        public CBool UseNewSpawnMethod
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("cpoItemCategory")]
        public TweakDBID CpoItemCategory
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("visualTags")]
        public CArray<CName> VisualTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("dropObject")]
        public CName DropObject
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("replicateWhenNotActive")]
        public CBool ReplicateWhenNotActive
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("dropSettings")]
        public TweakDBID DropSettings
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("isGarment")]
        public CBool IsGarment
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("audioName")]
        public CName AudioName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("equivalent")]
        public TweakDBID Equivalent
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("animName")]
        public CName AnimName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("isSingleInstance")]
        public CBool IsSingleInstance
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("itemSecondaryAction")]
        public TweakDBID ItemSecondaryAction
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("statModifiers")]
        public CArray<TweakDBID> StatModifiers
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("localizedName")]
        public CString LocalizedName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("audioSwitchValue")]
        public CName AudioSwitchValue
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("OnAttach")]
        public CArray<TweakDBID> OnAttach
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("icon")]
        public TweakDBID Icon
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("isCustomizable")]
        public CBool IsCustomizable
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("equipSoundMetadata")]
        public CName EquipSoundMetadata
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("displayName")]
        public gamedataLocKeyWrapper DisplayName
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("mass")]
        public CFloat Mass
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("tags")]
        public CArray<CName> Tags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("weakspots")]
        public CArray<TweakDBID> Weakspots
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("equipArea")]
        public TweakDBID EquipArea
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("appearanceSuffixes")]
        public CArray<TweakDBID> AppearanceSuffixes
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("OnLooted")]
        public CArray<TweakDBID> OnLooted
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("movementPattern")]
        public CName MovementPattern
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("statPools")]
        public CArray<TweakDBID> StatPools
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("iconPath")]
        public CString IconPath
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("savable")]
        public CBool Savable
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("minigameInstance")]
        public TweakDBID MinigameInstance
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("appearanceResourceName")]
        public CName AppearanceResourceName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("onEquipStats")]
        public TweakDBID OnEquipStats
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("crosshair")]
        public TweakDBID Crosshair
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("isPart")]
        public CBool IsPart
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("parentAttachmentType")]
        public TweakDBID ParentAttachmentType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("movementSound")]
        public TweakDBID MovementSound
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("animationParameters")]
        public CArray<CName> AnimationParameters
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("slotPartList")]
        public CArray<TweakDBID> SlotPartList
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("enableNpcRPGData")]
        public CBool EnableNpcRPGData
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("OnEquip")]
        public CArray<TweakDBID> OnEquip
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("itemStructure")]
        public TweakDBID ItemStructure
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
