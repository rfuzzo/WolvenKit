namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMappinUIParamGroup_Record : gamedataTweakDBRecord
    {
        [RED("minFactor")]
        public CFloat MinFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxValue")]
        public CFloat MaxValue
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("quadratic")]
        public CBool Quadratic
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("quadraticPeakMultiplier")]
        public CFloat QuadraticPeakMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxFactor")]
        public CFloat MaxFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minValue")]
        public CFloat MinValue
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("valueOffset")]
        public CFloat ValueOffset
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
