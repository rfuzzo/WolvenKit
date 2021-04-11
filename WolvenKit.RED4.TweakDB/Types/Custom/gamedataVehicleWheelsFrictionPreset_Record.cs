namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleWheelsFrictionPreset_Record : gamedataTweakDBRecord
    {
        [RED("audioMaterialCoeff")]
        public CFloat AudioMaterialCoeff
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("displayName")]
        public CString DisplayName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("looseSurfaceLatResistanceCoeff")]
        public CFloat LooseSurfaceLatResistanceCoeff
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("frictionLongMultiplier")]
        public CFloat FrictionLongMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("looseSurfaceLongSpeedMax")]
        public CFloat LooseSurfaceLongSpeedMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("frictionLatMultiplier")]
        public CFloat FrictionLatMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("frictionCurveSet")]
        public raRef<CResource> FrictionCurveSet
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("looseSurfaceLongNonDriveResistanceCoeff")]
        public CFloat LooseSurfaceLongNonDriveResistanceCoeff
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("looseSurfaceLongDriveResistanceCoeff")]
        public CFloat LooseSurfaceLongDriveResistanceCoeff
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("looseSurfaceLatSpeedMax")]
        public CFloat LooseSurfaceLatSpeedMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
