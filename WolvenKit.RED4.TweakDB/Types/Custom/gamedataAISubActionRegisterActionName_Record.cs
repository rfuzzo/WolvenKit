namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionRegisterActionName_Record : gamedataTweakDBRecord
    {
        [RED("actionName")]
        public CName ActionName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
