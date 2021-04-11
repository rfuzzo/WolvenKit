namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataLookAtPart_Record : gamedataTweakDBRecord
    {
        [RED("partName")]
        public CName PartName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("suppress")]
        public CFloat Suppress
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("weight")]
        public CFloat Weight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("mode")]
        public CInt32 Mode
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
