namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataEnvLight_Record : gamedataTweakDBRecord
    {
        [RED("radius")]
        public CFloat Radius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("temperature")]
        public CFloat Temperature
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("color")]
        public CArray<CInt32> Color
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("intensity")]
        public CFloat Intensity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
