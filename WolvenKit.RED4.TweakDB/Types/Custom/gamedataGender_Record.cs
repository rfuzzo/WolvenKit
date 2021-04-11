namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataGender_Record : gamedataTweakDBRecord
    {
        [RED("comment")]
        public CString Comment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
