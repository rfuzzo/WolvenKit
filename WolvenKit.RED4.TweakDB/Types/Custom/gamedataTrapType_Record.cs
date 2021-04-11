namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataTrapType_Record : gamedataTweakDBRecord
    {
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
