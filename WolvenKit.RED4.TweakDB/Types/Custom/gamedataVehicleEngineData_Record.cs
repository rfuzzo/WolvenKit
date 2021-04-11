namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleEngineData_Record : gamedataTweakDBRecord
    {
        [RED("maxRPM")]
        public CFloat MaxRPM
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("gearChangeCooldown")]
        public CFloat GearChangeCooldown
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("clutchSyncTorqueMul")]
        public CFloat ClutchSyncTorqueMul
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("gearCurvesPath")]
        public raRef<CResource> GearCurvesPath
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("gearChangeTime")]
        public CFloat GearChangeTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("gears")]
        public CArray<TweakDBID> Gears
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("flyWheelMomentOfInertia")]
        public CFloat FlyWheelMomentOfInertia
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("engineMaxTorque")]
        public CFloat EngineMaxTorque
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minRPM")]
        public CFloat MinRPM
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("forceReverseRPMToMin")]
        public CBool ForceReverseRPMToMin
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("resistanceTorque")]
        public CFloat ResistanceTorque
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("wheelsResistanceRatio")]
        public CFloat WheelsResistanceRatio
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("clutchSyncTorqueWheelMul")]
        public CFloat ClutchSyncTorqueWheelMul
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("instantR1GearChange")]
        public CBool InstantR1GearChange
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
