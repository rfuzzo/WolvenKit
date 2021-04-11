namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCharacter_Record : gamedataTweakDBRecord
    {
        [RED("shieldControllerDestroyed_staggerThreshold")]
        public CFloat ShieldControllerDestroyed_staggerThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("statusEffectParamsPackageName")]
        public CString StatusEffectParamsPackageName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("sizeFront")]
        public CFloat SizeFront
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("preferedWeapon")]
        public CName PreferedWeapon
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("speedIdleThreshold")]
        public CFloat SpeedIdleThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("walkTiltCoefficient")]
        public CFloat WalkTiltCoefficient
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("hide_nametag_displayname")]
        public CBool Hide_nametag_displayname
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("stats")]
        public CArray<TweakDBID> Stats
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("startingRecoveryBalance")]
        public CFloat StartingRecoveryBalance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("actionParamsPackageName")]
        public CString ActionParamsPackageName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("nameplate")]
        public CBool Nameplate
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("keepColliderOnDeath")]
        public CBool KeepColliderOnDeath
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("sizeLeft")]
        public CFloat SizeLeft
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("sizeRight")]
        public CFloat SizeRight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("airDeathRagdollDelay")]
        public CFloat AirDeathRagdollDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("globalSquads")]
        public CName GlobalSquads
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("sizeBack")]
        public CFloat SizeBack
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("tiltAngleOnSpeed")]
        public CFloat TiltAngleOnSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("saveStatPools")]
        public CBool SaveStatPools
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("combatDefaultZOffset")]
        public CFloat CombatDefaultZOffset
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("relaxedSensesPreset")]
        public CString RelaxedSensesPreset
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("communitySquads")]
        public CArray<CName> CommunitySquads
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("BodyDisposalFact")]
        public CName BodyDisposalFact
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("hasToBeKilledInWounded")]
        public CBool HasToBeKilledInWounded
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("massNormalizedCoefficient")]
        public CFloat MassNormalizedCoefficient
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("alertedSensesPreset")]
        public CString AlertedSensesPreset
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("hide_nametag")]
        public CBool Hide_nametag
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("combatSensesPreset")]
        public CString CombatSensesPreset
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }

        [RED("temp_doNotNotifySS")]
        public CBool Temp_doNotNotifySS
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("turnInertiaDamping")]
        public CFloat TurnInertiaDamping
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }

        [RED("pseudoAcceleration")]
        public CFloat PseudoAcceleration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("mass")]
        public CFloat Mass
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("weaponSlot")]
        public CName WeaponSlot
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
        
        [RED("minigameInstance")]
        public TweakDBID MinigameInstance
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("communitySquad")]
        public CName CommunitySquad
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("cpoClassName")]
        public CName CpoClassName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("audioMeleeMaterial")]
        public CName AudioMeleeMaterial
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("priority")]
        public TweakDBID Priority
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("threatTrackingPreset")]
        public TweakDBID ThreatTrackingPreset
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("lootBagEntity")]
        public CName LootBagEntity
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("displayDescription")]
        public gamedataLocKeyWrapper DisplayDescription
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("archetypeName")]
        public CName ArchetypeName
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
        
        [RED("audioResourceName")]
        public CName AudioResourceName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("onSpawnGLPs")]
        public CArray<TweakDBID> OnSpawnGLPs
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("fullDisplayName")]
        public gamedataLocKeyWrapper FullDisplayName
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("hasDirectionalStarts")]
        public CBool HasDirectionalStarts
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("itemGroups")]
        public CArray<TweakDBID> ItemGroups
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("voiceTag")]
        public CName VoiceTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("defaultCrosshair")]
        public TweakDBID DefaultCrosshair
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("devNotes")]
        public CString DevNotes
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("baseAttitudeGroup")]
        public CName BaseAttitudeGroup
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("driving")]
        public TweakDBID Driving
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("affiliation")]
        public TweakDBID Affiliation
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("canHaveGenericTalk")]
        public CBool CanHaveGenericTalk
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("primaryEquipment")]
        public TweakDBID PrimaryEquipment
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("idleActions")]
        public TweakDBID IdleActions
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("staticCommunityAppearancesDistributionEnabled")]
        public CBool StaticCommunityAppearancesDistributionEnabled
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("dropsAmmoOnDeath")]
        public CBool DropsAmmoOnDeath
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("reactionPreset")]
        public TweakDBID ReactionPreset
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
        
        [RED("actionMap")]
        public TweakDBID ActionMap
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("securitySquad")]
        public CName SecuritySquad
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("defaultEquipment")]
        public TweakDBID DefaultEquipment
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("isChild")]
        public CBool IsChild
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("sensePreset")]
        public TweakDBID SensePreset
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("quest")]
        public TweakDBID Quest
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
        
        [RED("uiNameplate")]
        public TweakDBID UiNameplate
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("objectActions")]
        public CArray<TweakDBID> ObjectActions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("dropsMoneyOnDeath")]
        public CBool DropsMoneyOnDeath
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("cpoCharacterBuild")]
        public CString CpoCharacterBuild
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("abilities")]
        public CArray<TweakDBID> Abilities
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
        
        [RED("contentAssignment")]
        public TweakDBID ContentAssignment
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("weakspots")]
        public CArray<TweakDBID> Weakspots
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("savable")]
        public CBool Savable
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("multiplayerTemplatePaths")]
        public CArray<raRef<CResource>> MultiplayerTemplatePaths
        {
            get => GetProperty<CArray<raRef<CResource>>>();
            set => SetProperty<CArray<raRef<CResource>>>(value);
        }
        
        [RED("vendorID")]
        public TweakDBID VendorID
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("statPools")]
        public CArray<TweakDBID> StatPools
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("crowdAppearanceNames")]
        public CArray<CName> CrowdAppearanceNames
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("dropsWeaponOnDeath")]
        public CBool DropsWeaponOnDeath
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("stateMachineName")]
        public CName StateMachineName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("forcedTBHZOffset")]
        public CFloat ForcedTBHZOffset
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("level")]
        public CInt32 Level
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("crowdMemberSettings")]
        public TweakDBID CrowdMemberSettings
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("rarity")]
        public TweakDBID Rarity
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("EquipmentAreas")]
        public CArray<TweakDBID> EquipmentAreas
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("squadParamsID")]
        public TweakDBID SquadParamsID
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("scannerModulePreset")]
        public TweakDBID ScannerModulePreset
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("entityTemplatePath")]
        public raRef<CResource> EntityTemplatePath
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("alternativeFullDisplayName")]
        public gamedataLocKeyWrapper AlternativeFullDisplayName
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("bountyDrawTable")]
        public TweakDBID BountyDrawTable
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("despawnChildCommunityWhenPlayerInVehicle")]
        public CBool DespawnChildCommunityWhenPlayerInVehicle
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("forceCanHaveGenericTalk")]
        public CBool ForceCanHaveGenericTalk
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("effectors")]
        public CArray<TweakDBID> Effectors
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
        
        [RED("isBumpable")]
        public CBool IsBumpable
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("isLightCrowd")]
        public CBool IsLightCrowd
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("tags")]
        public CArray<CName> Tags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("archetypeData")]
        public TweakDBID ArchetypeData
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("characterType")]
        public TweakDBID CharacterType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("items")]
        public CArray<TweakDBID> Items
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("genders")]
        public CArray<TweakDBID> Genders
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("secondaryEquipment")]
        public TweakDBID SecondaryEquipment
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("displayName")]
        public gamedataLocKeyWrapper DisplayName
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("isCrowd")]
        public CBool IsCrowd
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("enableSensesOnStart")]
        public CBool EnableSensesOnStart
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("globalSquad")]
        public CName GlobalSquad
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("lootDrop")]
        public TweakDBID LootDrop
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("persistentName")]
        public CName PersistentName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("skipDisplayArchetype")]
        public CBool SkipDisplayArchetype
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("alternativeDisplayName")]
        public gamedataLocKeyWrapper AlternativeDisplayName
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
    }
}
