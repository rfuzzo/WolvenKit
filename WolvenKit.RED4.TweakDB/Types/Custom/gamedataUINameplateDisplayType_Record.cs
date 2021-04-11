namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataUINameplateDisplayType_Record : gamedataTweakDBRecord
    {
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("comment")]
        public CString Comment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
