namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCurve_Record : gamedataTweakDBRecord
    {
        [RED("curveName")]
        public CName CurveName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("curveSetName")]
        public CName CurveSetName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
