namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataParentAttachmentType_Record : gamedataTweakDBRecord
    {
        [RED("comment")]
        public CString Comment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("name")]
        public CString Name
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
