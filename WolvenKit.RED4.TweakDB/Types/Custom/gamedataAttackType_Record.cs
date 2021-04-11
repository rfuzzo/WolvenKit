namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAttackType_Record : gamedataTweakDBRecord
    {
        [RED("name")]
        public CString Name
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("comment")]
        public CString Comment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
