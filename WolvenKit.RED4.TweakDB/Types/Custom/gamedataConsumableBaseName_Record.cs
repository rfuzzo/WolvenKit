namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataConsumableBaseName_Record : gamedataTweakDBRecord
    {
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("enumComment")]
        public CName EnumComment
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
