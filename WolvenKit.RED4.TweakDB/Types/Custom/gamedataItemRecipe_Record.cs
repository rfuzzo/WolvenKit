namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataItemRecipe_Record : gamedataTweakDBRecord
    {
        [RED("stateMachineName")]
        public CName StateMachineName
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
        
        [RED("hideOnItemsAdded")]
        public CArray<TweakDBID> HideOnItemsAdded
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
        
        [RED("replicateWhenNotActive")]
        public CBool ReplicateWhenNotActive
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("blueprint")]
        public TweakDBID Blueprint
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("dropSettings")]
        public TweakDBID DropSettings
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("placementSlots")]
        public CArray<TweakDBID> PlacementSlots
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
        
        [RED("localizedDescription")]
        public gamedataLocKeyWrapper LocalizedDescription
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("appearanceName")]
        public CName AppearanceName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("iconPath")]
        public CString IconPath
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("npcRPGData")]
        public TweakDBID NpcRPGData
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
        
        [RED("OnLooted")]
        public CArray<TweakDBID> OnLooted
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("animSetResource")]
        public raRef<CResource> AnimSetResource
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("gameplayRestrictions")]
        public CArray<TweakDBID> GameplayRestrictions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("animName")]
        public CName AnimName
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
        
        [RED("equipSoundMetadata")]
        public CName EquipSoundMetadata
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
        
        [RED("equipAreas")]
        public CArray<TweakDBID> EquipAreas
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
        
        [RED("onEquipStats")]
        public TweakDBID OnEquipStats
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
        
        [RED("objectActions")]
        public CArray<TweakDBID> ObjectActions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("appearanceResourceName")]
        public CName AppearanceResourceName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("sellPrice")]
        public CArray<TweakDBID> SellPrice
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("animFeatureName")]
        public CName AnimFeatureName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("garmentOffset")]
        public CInt32 GarmentOffset
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("OnEquip")]
        public CArray<TweakDBID> OnEquip
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("tags")]
        public CArray<CName> Tags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("mass")]
        public CFloat Mass
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("weakspots")]
        public CArray<TweakDBID> Weakspots
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("useNewSpawnMethod")]
        public CBool UseNewSpawnMethod
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("enableNpcRPGData")]
        public CBool EnableNpcRPGData
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("friendlyName")]
        public CString FriendlyName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("icon")]
        public TweakDBID Icon
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("cpoItemCategory")]
        public TweakDBID CpoItemCategory
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("equipArea")]
        public TweakDBID EquipArea
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("attachmentSlots")]
        public CArray<TweakDBID> AttachmentSlots
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
        
        [RED("cameraUp")]
        public Vector3 CameraUp
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("savable")]
        public CBool Savable
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("craftingResult")]
        public TweakDBID CraftingResult
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
        
        [RED("movementSound")]
        public TweakDBID MovementSound
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
        
        [RED("itemSecondaryAction")]
        public TweakDBID ItemSecondaryAction
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("itemStructure")]
        public TweakDBID ItemStructure
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("equipPrereqs")]
        public CArray<TweakDBID> EquipPrereqs
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("isCustomizable")]
        public CBool IsCustomizable
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
        
        [RED("effectors")]
        public CArray<TweakDBID> Effectors
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
        
        [RED("CraftingData")]
        public TweakDBID CraftingData
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
        
        [RED("visualTags")]
        public CArray<CName> VisualTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("audioSwitchValue")]
        public CName AudioSwitchValue
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("dropObject")]
        public CName DropObject
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
        
        [RED("isSingleInstance")]
        public CBool IsSingleInstance
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("appearanceSuffixesOwnerOverride")]
        public CArray<CBool> AppearanceSuffixesOwnerOverride
        {
            get => GetProperty<CArray<CBool>>();
            set => SetProperty<CArray<CBool>>(value);
        }
        
        [RED("buyPrice")]
        public CArray<TweakDBID> BuyPrice
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("displayName")]
        public gamedataLocKeyWrapper DisplayName
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
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
        
        [RED("parts")]
        public CArray<TweakDBID> Parts
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("statModifiers")]
        public CArray<TweakDBID> StatModifiers
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("equivalent")]
        public TweakDBID Equivalent
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
        
        [RED("animationParameters")]
        public CArray<CName> AnimationParameters
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("parentAttachmentType")]
        public TweakDBID ParentAttachmentType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("itemType")]
        public TweakDBID ItemType
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
        
        [RED("slotPartListPreset")]
        public CArray<TweakDBID> SlotPartListPreset
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
