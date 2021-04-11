namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataWidgetStyle_Record : gamedataTweakDBRecord
    {
        [RED("enumName")]
        public CString EnumName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
