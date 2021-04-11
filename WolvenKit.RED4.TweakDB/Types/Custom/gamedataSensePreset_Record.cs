namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataSensePreset_Record : gamedataTweakDBRecord
    {
        [RED("objectType")]
        public TweakDBID ObjectType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("materialCurves")]
        public CArray<TweakDBID> MaterialCurves
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("detectionCoolDownTime")]
        public CFloat DetectionCoolDownTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("useZCorrection")]
        public CBool UseZCorrection
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("detectionPartCoolDownTime")]
        public CFloat DetectionPartCoolDownTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("detectionDropFactor")]
        public CFloat DetectionDropFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("shapes")]
        public CArray<TweakDBID> Shapes
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("dayNightCurve")]
        public CName DayNightCurve
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("curves")]
        public CArray<TweakDBID> Curves
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("ignorePhysicsTest")]
        public CBool IgnorePhysicsTest
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("detectionFactor")]
        public CFloat DetectionFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
