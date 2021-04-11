namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPlayerPossesion_Record : gamedataTweakDBRecord
    {
        [RED("enumName")]
        public CString EnumName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("enumComment")]
        public CString EnumComment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
