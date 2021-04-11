namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIActionCondition_Record : gamedataTweakDBRecord
    {
        [RED("spatialAND")]
        public CArray<TweakDBID> SpatialAND
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("statPoolOR")]
        public CArray<TweakDBID> StatPoolOR
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("workspot")]
        public TweakDBID Workspot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("optimalDistance")]
        public TweakDBID OptimalDistance
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("statPoolAND")]
        public CArray<TweakDBID> StatPoolAND
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("calculatePath")]
        public CArray<TweakDBID> CalculatePath
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("restrictedMovementArea")]
        public CArray<TweakDBID> RestrictedMovementArea
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("vehicleOR")]
        public CArray<TweakDBID> VehicleOR
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("reaction")]
        public CArray<TweakDBID> Reaction
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("goToCover")]
        public TweakDBID GoToCover
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("slotOR")]
        public CArray<TweakDBID> SlotOR
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("hit")]
        public TweakDBID Hit
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("vehicleAND")]
        public CArray<TweakDBID> VehicleAND
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("squadOR")]
        public CArray<TweakDBID> SquadOR
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("blockCount")]
        public TweakDBID BlockCount
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("calculateLineOfSightVector")]
        public CArray<TweakDBID> CalculateLineOfSightVector
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("lookat")]
        public CArray<TweakDBID> Lookat
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("security")]
        public TweakDBID Security
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("commandOR")]
        public CArray<TweakDBID> CommandOR
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("validCover")]
        public TweakDBID ValidCover
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("npcType")]
        public TweakDBID NpcType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("inTacticPosition")]
        public CArray<TweakDBID> InTacticPosition
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("statusEffectOR")]
        public CArray<TweakDBID> StatusEffectOR
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("commandAND")]
        public CArray<TweakDBID> CommandAND
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("statusEffectAND")]
        public CArray<TweakDBID> StatusEffectAND
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("weakSpotOR")]
        public CArray<TweakDBID> WeakSpotOR
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("cooldown")]
        public CArray<TweakDBID> Cooldown
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("slotAND")]
        public CArray<TweakDBID> SlotAND
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("signalAND")]
        public CArray<TweakDBID> SignalAND
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("movementAND")]
        public CArray<TweakDBID> MovementAND
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("state")]
        public CArray<TweakDBID> State
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("weakSpotAND")]
        public CArray<TweakDBID> WeakSpotAND
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("cover")]
        public TweakDBID Cover
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("tresspassing")]
        public CArray<TweakDBID> Tresspassing
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("squadAND")]
        public CArray<TweakDBID> SquadAND
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("friendlyFire")]
        public TweakDBID FriendlyFire
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("spatialOR")]
        public CArray<TweakDBID> SpatialOR
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("ammoCountAND")]
        public CArray<TweakDBID> AmmoCountAND
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("weaponLockedOnTarget")]
        public TweakDBID WeaponLockedOnTarget
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("signalOR")]
        public CArray<TweakDBID> SignalOR
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("ammoCountOR")]
        public CArray<TweakDBID> AmmoCountOR
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("condition")]
        public TweakDBID Condition
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("previousAttack")]
        public TweakDBID PreviousAttack
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("dodgeCount")]
        public TweakDBID DodgeCount
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("canThrow")]
        public TweakDBID CanThrow
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("inventoryOR")]
        public CArray<TweakDBID> InventoryOR
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("weapon")]
        public TweakDBID Weapon
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("inventoryAND")]
        public CArray<TweakDBID> InventoryAND
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("movementOR")]
        public CArray<TweakDBID> MovementOR
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("ability")]
        public CArray<TweakDBID> Ability
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
