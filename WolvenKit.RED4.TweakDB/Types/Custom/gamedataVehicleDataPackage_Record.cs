namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleDataPackage_Record : gamedataTweakDBRecord
    {
        [RED("exiting")]
        public CFloat Exiting
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("hasTurboCharger")]
        public CBool HasTurboCharger
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("speedToClose")]
        public CFloat SpeedToClose
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("interactiveTrunk")]
        public CBool InteractiveTrunk
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("barnDoorsTailgate")]
        public CBool BarnDoorsTailgate
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("entering")]
        public CFloat Entering
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("seatingTemplateOverride")]
        public CName SeatingTemplateOverride
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("hasSiren")]
        public CBool HasSiren
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("disableSwitchSeats")]
        public CBool DisableSwitchSeats
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("toCombat")]
        public CFloat ToCombat
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("switchSeats")]
        public CFloat SwitchSeats
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("fromCombat")]
        public CFloat FromCombat
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("vehSeatSet")]
        public TweakDBID VehSeatSet
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("parkingAngle")]
        public CFloat ParkingAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("slidingRearDoors")]
        public CBool SlidingRearDoors
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("knockOffForce")]
        public CFloat KnockOffForce
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spoilerSpeedToDeploy")]
        public CFloat SpoilerSpeedToDeploy
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("stealing_open")]
        public CFloat Stealing_open
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("open_close_duration")]
        public CFloat Open_close_duration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("canStoreBody")]
        public CBool CanStoreBody
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("hasSpoiler")]
        public CBool HasSpoiler
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("boneNames")]
        public CArray<CName> BoneNames
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("animVars")]
        public CArray<CName> AnimVars
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("fppCameraOverride")]
        public CName FppCameraOverride
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("exitDelay")]
        public CFloat ExitDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spoilerSpeedToRetract")]
        public CFloat SpoilerSpeedToRetract
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("stealing")]
        public CFloat Stealing
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("supportsCombat")]
        public CBool SupportsCombat
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("normal_open")]
        public CFloat Normal_open
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("slideDuration")]
        public CFloat SlideDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("interactiveHood")]
        public CBool InteractiveHood
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
