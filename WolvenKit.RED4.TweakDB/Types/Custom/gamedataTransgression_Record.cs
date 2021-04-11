namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataTransgression_Record : gamedataTweakDBRecord
    {
        [RED("drawWeight")]
        public CFloat DrawWeight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("severity")]
        public CFloat Severity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("localizedDescription")]
        public CString LocalizedDescription
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
