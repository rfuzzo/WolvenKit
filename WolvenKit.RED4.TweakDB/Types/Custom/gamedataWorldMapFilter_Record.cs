namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataWorldMapFilter_Record : gamedataTweakDBRecord
    {
        [RED("enumComment")]
        public CString EnumComment
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
