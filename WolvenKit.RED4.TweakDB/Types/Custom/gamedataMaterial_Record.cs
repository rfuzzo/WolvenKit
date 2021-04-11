namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMaterial_Record : gamedataTweakDBRecord
    {
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
