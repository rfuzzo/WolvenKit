namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleDriveModelData_Record : gamedataTweakDBRecord
    {
        [RED("turningRollFactorWeakContactMul")]
        public CFloat TurningRollFactorWeakContactMul
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("tankDeceleration")]
        public CFloat TankDeceleration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("perfectSteeringFactor")]
        public CFloat PerfectSteeringFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("rollingResistanceFactor")]
        public CFloat RollingResistanceFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("bikeTiltSpeed")]
        public CFloat BikeTiltSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("slopeTractionReductionBegin")]
        public CFloat SlopeTractionReductionBegin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("slipRatioCurveScale")]
        public CFloat SlipRatioCurveScale
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("slopeTractionReductionMax")]
        public CFloat SlopeTractionReductionMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("wheelSetup")]
        public TweakDBID WheelSetup
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("tankMaxSpeed")]
        public CFloat TankMaxSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("tankSpringDamping")]
        public CFloat TankSpringDamping
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("slipAngleMinSpeedThreshold")]
        public CFloat SlipAngleMinSpeedThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("turnUpdateMaxSpeedThreshold")]
        public CFloat TurnUpdateMaxSpeedThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("sideWeightTransferFactor")]
        public CFloat SideWeightTransferFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("total_mass")]
        public CFloat Total_mass
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("tankGravityMul")]
        public CFloat TankGravityMul
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("turningRollFactorWeakContactThresholdMin")]
        public CFloat TurningRollFactorWeakContactThresholdMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("turningRollFactor")]
        public CFloat TurningRollFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("antiSwaybarDampingScalor")]
        public CFloat AntiSwaybarDampingScalor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("turnUpdateInputSlowChangeSpeed")]
        public CFloat TurnUpdateInputSlowChangeSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("smoothWheelContactDecreaseTime")]
        public CFloat SmoothWheelContactDecreaseTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("bikeTiltPID")]
        public CArray<CFloat> BikeTiltPID
        {
            get => GetProperty<CArray<CFloat>>();
            set => SetProperty<CArray<CFloat>>(value);
        }
        
        [RED("wheelTurnMaxSubPerSecond")]
        public CFloat WheelTurnMaxSubPerSecond
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("slipAngleCurveScale")]
        public CFloat SlipAngleCurveScale
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("turningRollFactorWeakContactThresholdMax")]
        public CFloat TurningRollFactorWeakContactThresholdMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("tankSpringsLocalPositions")]
        public CArray<Vector2> TankSpringsLocalPositions
        {
            get => GetProperty<CArray<Vector2>>();
            set => SetProperty<CArray<Vector2>>(value);
        }
        
        [RED("differentialOvershootFactor")]
        public CFloat DifferentialOvershootFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("tankAcceleration")]
        public CFloat TankAcceleration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("momentOfInertiaScale")]
        public Vector3 MomentOfInertiaScale
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("useAlternativeTurnUpdate")]
        public CBool UseAlternativeTurnUpdate
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("momentOfInertia")]
        public Vector3 MomentOfInertia
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("smoothWheelContactIncreseTime")]
        public CFloat SmoothWheelContactIncreseTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("bankBodyLRTanMultiplier")]
        public CFloat BankBodyLRTanMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("tankSpringDistance")]
        public CFloat TankSpringDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("bankBodyFBTanMultiplier")]
        public CFloat BankBodyFBTanMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("turnUpdateBaseSpeedThreshold")]
        public CFloat TurnUpdateBaseSpeedThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("airResistanceFactor")]
        public CFloat AirResistanceFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("slipRatioMinSpeedThreshold")]
        public CFloat SlipRatioMinSpeedThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxWheelTurnDeg")]
        public CFloat MaxWheelTurnDeg
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("slopeTractionReductionFactor")]
        public CFloat SlopeTractionReductionFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("forwardWeightTransferFactor")]
        public CFloat ForwardWeightTransferFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("tankCTOI")]
        public CFloat TankCTOI
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("turnUpdateInputDiffForFastChange")]
        public CFloat TurnUpdateInputDiffForFastChange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("handbrakeBrakingTorque")]
        public CFloat HandbrakeBrakingTorque
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("lowVelStoppingDeceleration")]
        public CFloat LowVelStoppingDeceleration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("bikeMaxTilt")]
        public CFloat BikeMaxTilt
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("bikeTiltCustomSpeed")]
        public CFloat BikeTiltCustomSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("tankTurningSpeed")]
        public CFloat TankTurningSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("turnUpdateMaxSpeedTurnChangeMul")]
        public CFloat TurnUpdateMaxSpeedTurnChangeMul
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("turnUpdateInputDiffForSlowChange")]
        public CFloat TurnUpdateInputDiffForSlowChange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("turnUpdateInputDiffProgressionPow")]
        public CFloat TurnUpdateInputDiffProgressionPow
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("turnUpdateMaxSpeedTurnMul")]
        public CFloat TurnUpdateMaxSpeedTurnMul
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("driveHelpers")]
        public CArray<TweakDBID> DriveHelpers
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("tankSpringStiffness")]
        public CFloat TankSpringStiffness
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("bikeTiltReturnSpeed")]
        public CFloat BikeTiltReturnSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("center_of_mass_offset")]
        public Vector3 Center_of_mass_offset
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("brakingFrictionFactor")]
        public CFloat BrakingFrictionFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("tankSpringRadius")]
        public CFloat TankSpringRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("tankSpringVerticalOffset")]
        public CFloat TankSpringVerticalOffset
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("wheelTurnMaxAddPerSecond")]
        public CFloat WheelTurnMaxAddPerSecond
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("tankCTOD")]
        public CFloat TankCTOD
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("waterParams")]
        public TweakDBID WaterParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("wheelsFrictionMap")]
        public TweakDBID WheelsFrictionMap
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("burnOutRotationModifier")]
        public CFloat BurnOutRotationModifier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("bodyFriction")]
        public CFloat BodyFriction
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("bikeCurvesPath")]
        public raRef<CResource> BikeCurvesPath
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("turnUpdateInputFastChangeSpeed")]
        public CFloat TurnUpdateInputFastChangeSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("chassis_mass")]
        public CFloat Chassis_mass
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("tankCTOP")]
        public CFloat TankCTOP
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
