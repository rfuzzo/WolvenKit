namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIExposureMethodType_Record : gamedataTweakDBRecord
    {
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("enumComment")]
        public CString EnumComment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("priority")]
        public CArray<CInt32> Priority
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
    }
}
