namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataItemCategory_Record : gamedataTweakDBRecord
    {
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("localizedCategory")]
        public gamedataLocKeyWrapper LocalizedCategory
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
    }
}
