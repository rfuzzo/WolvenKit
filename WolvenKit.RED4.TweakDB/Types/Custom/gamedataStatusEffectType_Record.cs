namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataStatusEffectType_Record : gamedataTweakDBRecord
    {
        [RED("enumComment")]
        public CString EnumComment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("enumName")]
        public CString EnumName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
