namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataNonLinearAccuracy_Record : gamedataAccuracy_Record
    {
        [RED("timeFactor")]
        public CFloat TimeFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("exponent")]
        public CFloat Exponent
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
