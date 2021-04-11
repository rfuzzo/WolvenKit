namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataConsumableType_Record : gamedataTweakDBRecord
    {
        [RED("enumComment")]
        public CName EnumComment
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
