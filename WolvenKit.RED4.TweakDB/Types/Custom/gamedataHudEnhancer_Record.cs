namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataHudEnhancer_Record : gamedataTweakDBRecord
    {
        [RED("coneAngle")]
        public CFloat ConeAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("distance")]
        public CFloat Distance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
