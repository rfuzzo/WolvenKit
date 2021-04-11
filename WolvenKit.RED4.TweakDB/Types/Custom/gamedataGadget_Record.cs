namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataGadget_Record : gamedataTweakDBRecord
    {
        [RED("price")]
        public TweakDBID Price
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("localizedName")]
        public CString LocalizedName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("rangedAttacks")]
        public TweakDBID RangedAttacks
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("useNewSpawnMethod")]
        public CBool UseNewSpawnMethod
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("statModifierGroups")]
        public CArray<TweakDBID> StatModifierGroups
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("crosshair")]
        public TweakDBID Crosshair
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
        
        [RED("manufacturer")]
        public TweakDBID Manufacturer
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
        
        [RED("statModifiers")]
        public CArray<TweakDBID> StatModifiers
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("audioSwitchValue")]
        public CName AudioSwitchValue
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("equipArea")]
        public TweakDBID EquipArea
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("audioSwitchName")]
        public CName AudioSwitchName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("damageType")]
        public TweakDBID DamageType
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
        
        [RED("slotPartList")]
        public CArray<TweakDBID> SlotPartList
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("statPools")]
        public CArray<TweakDBID> StatPools
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("forcedMinHitReaction")]
        public CInt32 ForcedMinHitReaction
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("animationParameters")]
        public CArray<CName> AnimationParameters
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("requiredSlots")]
        public CArray<TweakDBID> RequiredSlots
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("slotPartListPreset")]
        public CArray<TweakDBID> SlotPartListPreset
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
        
        [RED("isSingleInstance")]
        public CBool IsSingleInstance
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("cameraForward")]
        public Vector3 CameraForward
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("animSetResource")]
        public raRef<CResource> AnimSetResource
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("parts")]
        public CArray<TweakDBID> Parts
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
        
        [RED("onEquipStats")]
        public TweakDBID OnEquipStats
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("connections")]
        public CArray<TweakDBID> Connections
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("weakspots")]
        public CArray<TweakDBID> Weakspots
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("quality")]
        public TweakDBID Quality
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
        
        [RED("minigameInstance")]
        public TweakDBID MinigameInstance
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("icon")]
        public TweakDBID Icon
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
        
        [RED("mass")]
        public CFloat Mass
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("itemStructure")]
        public TweakDBID ItemStructure
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("tags")]
        public CArray<CName> Tags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("audioName")]
        public CName AudioName
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
        
        [RED("isGarment")]
        public CBool IsGarment
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("equivalent")]
        public TweakDBID Equivalent
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
        
        [RED("enableNpcRPGData")]
        public CBool EnableNpcRPGData
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
        
        [RED("dropObject")]
        public CName DropObject
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
        
        [RED("previewEffectName")]
        public CName PreviewEffectName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("isCustomizable")]
        public CBool IsCustomizable
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
        
        [RED("effectors")]
        public CArray<TweakDBID> Effectors
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("dropSettings")]
        public TweakDBID DropSettings
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
        
        [RED("animFeatureName")]
        public CName AnimFeatureName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("previewEffectTag")]
        public CName PreviewEffectTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("npcRPGData")]
        public TweakDBID NpcRPGData
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("garmentOffset")]
        public CInt32 GarmentOffset
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("useForcedTBHZOffset")]
        public CBool UseForcedTBHZOffset
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
        
        [RED("cpoItemCategory")]
        public TweakDBID CpoItemCategory
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("attacks")]
        public CArray<TweakDBID> Attacks
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("cameraUp")]
        public Vector3 CameraUp
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("replicateWhenNotActive")]
        public CBool ReplicateWhenNotActive
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("attachmentSlots")]
        public CArray<TweakDBID> AttachmentSlots
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("appearanceSuffixes")]
        public CArray<TweakDBID> AppearanceSuffixes
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("objectActions")]
        public CArray<TweakDBID> ObjectActions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("effectiveRangeCurve")]
        public CName EffectiveRangeCurve
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("itemCategory")]
        public TweakDBID ItemCategory
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("localizedDescription")]
        public gamedataLocKeyWrapper LocalizedDescription
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("primaryTriggerMode")]
        public TweakDBID PrimaryTriggerMode
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("blueprint")]
        public TweakDBID Blueprint
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("CraftingData")]
        public TweakDBID CraftingData
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("gameplayRestrictions")]
        public CArray<TweakDBID> GameplayRestrictions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("entityName")]
        public CName EntityName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("fxPackage")]
        public TweakDBID FxPackage
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("hairSkinnedMeshComponents")]
        public CArray<CName> HairSkinnedMeshComponents
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("appearanceSuffixesOwnerOverride")]
        public CArray<CBool> AppearanceSuffixesOwnerOverride
        {
            get => GetProperty<CArray<CBool>>();
            set => SetProperty<CArray<CBool>>(value);
        }
        
        [RED("sellPrice")]
        public CArray<TweakDBID> SellPrice
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("fxPackageQuickMelee")]
        public TweakDBID FxPackageQuickMelee
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("hudIcon")]
        public TweakDBID HudIcon
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
        
        [RED("movementPattern")]
        public CName MovementPattern
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("evolution")]
        public TweakDBID Evolution
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("triggerModes")]
        public CArray<TweakDBID> TriggerModes
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("OnEquip")]
        public CArray<TweakDBID> OnEquip
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("equipPrereqs")]
        public CArray<TweakDBID> EquipPrereqs
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
        
        [RED("effectiveRangeFalloffCurve")]
        public CName EffectiveRangeFalloffCurve
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("appearanceResourceName")]
        public CName AppearanceResourceName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("equipAreas")]
        public CArray<TweakDBID> EquipAreas
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("appearanceName")]
        public CName AppearanceName
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
        
        [RED("stateMachineName")]
        public CName StateMachineName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("friendlyName")]
        public CString FriendlyName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("placementSlots")]
        public CArray<TweakDBID> PlacementSlots
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
        
        [RED("savable")]
        public CBool Savable
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("isPart")]
        public CBool IsPart
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("audioWeaponConfiguration")]
        public CName AudioWeaponConfiguration
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
