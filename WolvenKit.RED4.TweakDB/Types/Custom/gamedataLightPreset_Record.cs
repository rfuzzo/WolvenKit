namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataLightPreset_Record : gamedataTweakDBRecord
    {
        [RED("force")]
        public CBool Force
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("loop")]
        public CBool Loop
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("overrideColorMin")]
        public CBool OverrideColorMin
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("duration")]
        public CFloat Duration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("colorMin")]
        public CArray<CInt32> ColorMin
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("colorMax")]
        public CArray<CInt32> ColorMax
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("curve")]
        public CName Curve
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("strength")]
        public CFloat Strength
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("on")]
        public CBool On
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("time")]
        public CFloat Time
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
