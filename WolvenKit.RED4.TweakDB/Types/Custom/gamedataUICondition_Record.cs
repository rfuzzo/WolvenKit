namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataUICondition_Record : gamedataTweakDBRecord
    {
        [RED("isCustom")]
        public CBool IsCustom
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
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
    }
}
