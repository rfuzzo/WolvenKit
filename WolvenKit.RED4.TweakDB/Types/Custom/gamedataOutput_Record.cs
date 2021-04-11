namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataOutput_Record : gamedataTweakDBRecord
    {
        [RED("AIPriority")]
        public CFloat AIPriority
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("outputName")]
        public CString OutputName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("priority")]
        public CInt32 Priority
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
