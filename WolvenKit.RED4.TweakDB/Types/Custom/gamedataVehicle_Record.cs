namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicle_Record : gamedataTweakDBRecord
    {
        [RED("fullDisplayName")]
        public CString FullDisplayName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("hijackDifficulty")]
        public CString HijackDifficulty
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("crackLockDifficulty")]
        public CString CrackLockDifficulty
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("manufacturer")]
        public TweakDBID Manufacturer
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("vehEngineData")]
        public TweakDBID VehEngineData
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
        
        [RED("rightFrontCamber")]
        public CFloat RightFrontCamber
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("statModifierGroups")]
        public CArray<TweakDBID> StatModifierGroups
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("fxWheelsDecals")]
        public TweakDBID FxWheelsDecals
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("vehBehaviorData")]
        public TweakDBID VehBehaviorData
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("traffic_audio_resource")]
        public CString Traffic_audio_resource
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("visualDestruction")]
        public TweakDBID VisualDestruction
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
        
        [RED("vehPassCombatL_FPPCameraParams")]
        public TweakDBID VehPassCombatL_FPPCameraParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("leftBlinkerlightColor")]
        public CArray<CInt32> LeftBlinkerlightColor
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("curvesPath")]
        public raRef<CResource> CurvesPath
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("vehPassR_ProceduralFPPCameraParams")]
        public TweakDBID VehPassR_ProceduralFPPCameraParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("widgetStyleSheetPath")]
        public raRef<CResource> WidgetStyleSheetPath
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("leftFrontCamber")]
        public CFloat LeftFrontCamber
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("vehImpactTraffic")]
        public TweakDBID VehImpactTraffic
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("weapons")]
        public CArray<TweakDBID> Weapons
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("vehDriver_FPPCameraParams")]
        public TweakDBID VehDriver_FPPCameraParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("leftFrontCamberOffset")]
        public Vector3 LeftFrontCamberOffset
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("vehPassL_ProceduralFPPCameraParams")]
        public TweakDBID VehPassL_ProceduralFPPCameraParams
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
        
        [RED("type")]
        public TweakDBID Type
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
        
        [RED("attachmentSlots")]
        public CArray<TweakDBID> AttachmentSlots
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("vehPassCombatR_FPPCameraParams")]
        public TweakDBID VehPassCombatR_FPPCameraParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("rightBackCamberOffset")]
        public Vector3 RightBackCamberOffset
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("rightBLinkerlightColor")]
        public CArray<CInt32> RightBLinkerlightColor
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("interiorColor")]
        public CArray<CInt32> InteriorColor
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("vehDriverCombat_FPPCameraParams")]
        public TweakDBID VehDriverCombat_FPPCameraParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("vehCrowdCollisionParams")]
        public TweakDBID VehCrowdCollisionParams
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
        
        [RED("vehDefaultState")]
        public TweakDBID VehDefaultState
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("vehicleUIData")]
        public TweakDBID VehicleUIData
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("driving")]
        public TweakDBID Driving
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("vehDriveModelDataAI")]
        public TweakDBID VehDriveModelDataAI
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("model")]
        public TweakDBID Model
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("appearanceName")]
        public CName AppearanceName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("vehDriveModelData")]
        public TweakDBID VehDriveModelData
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("rightFrontCamberOffset")]
        public Vector3 RightFrontCamberOffset
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("visualTags")]
        public CArray<CName> VisualTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("affiliation")]
        public TweakDBID Affiliation
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("audioResourceName")]
        public CName AudioResourceName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("fxWheelsParticles")]
        public TweakDBID FxWheelsParticles
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("vehPassR_FPPCameraParams")]
        public TweakDBID VehPassR_FPPCameraParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("vehPassCombatR_ProceduralFPPCameraParams")]
        public TweakDBID VehPassCombatR_ProceduralFPPCameraParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("cameraManagerParams")]
        public TweakDBID CameraManagerParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("enableDestruction")]
        public CBool EnableDestruction
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("fxCollision")]
        public TweakDBID FxCollision
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
        
        [RED("vehWheelDimensionsSetup")]
        public TweakDBID VehWheelDimensionsSetup
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
        
        [RED("priority")]
        public TweakDBID Priority
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("rightBackCamber")]
        public CFloat RightBackCamber
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("icon")]
        public TweakDBID Icon
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("vehPassCombatL_ProceduralFPPCameraParams")]
        public TweakDBID VehPassCombatL_ProceduralFPPCameraParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("vehDataPackage")]
        public TweakDBID VehDataPackage
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("headlightColor")]
        public CArray<CInt32> HeadlightColor
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("interiorDamageColor")]
        public CArray<CInt32> InteriorDamageColor
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("queryOnlyExceptions")]
        public CArray<CName> QueryOnlyExceptions
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("multiplayerTemplatePaths")]
        public CArray<raRef<CResource>> MultiplayerTemplatePaths
        {
            get => GetProperty<CArray<raRef<CResource>>>();
            set => SetProperty<CArray<raRef<CResource>>>(value);
        }
        
        [RED("savable")]
        public CBool Savable
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("vehDriverCombat_ProceduralFPPCameraParams")]
        public TweakDBID VehDriverCombat_ProceduralFPPCameraParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("vehAirControl")]
        public TweakDBID VehAirControl
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("reverselightColor")]
        public CArray<CInt32> ReverselightColor
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("randomPassengers")]
        public CArray<TweakDBID> RandomPassengers
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("unmountOffsetPosition")]
        public Vector3 UnmountOffsetPosition
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("crowdMemberSettings")]
        public TweakDBID CrowdMemberSettings
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("vehAirControlAI")]
        public TweakDBID VehAirControlAI
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("vehPassL_FPPCameraParams")]
        public TweakDBID VehPassL_FPPCameraParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("leftBackCamber")]
        public CFloat LeftBackCamber
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("destruction")]
        public TweakDBID Destruction
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
        
        [RED("tppCameraPresets")]
        public CArray<TweakDBID> TppCameraPresets
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("brakelightColor")]
        public CArray<CInt32> BrakelightColor
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("leftBackCamberOffset")]
        public Vector3 LeftBackCamberOffset
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("vehDriver_ProceduralFPPCameraParams")]
        public TweakDBID VehDriver_ProceduralFPPCameraParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("player_audio_resource")]
        public CString Player_audio_resource
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("displayName")]
        public gamedataLocKeyWrapper DisplayName
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("destroyedAppearance")]
        public CName DestroyedAppearance
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("archetypeName")]
        public CName ArchetypeName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("tppCameraParams")]
        public TweakDBID TppCameraParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
