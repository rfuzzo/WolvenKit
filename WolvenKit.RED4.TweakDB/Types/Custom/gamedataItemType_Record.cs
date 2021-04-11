namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataItemType_Record : gamedataTweakDBRecord
    {
        [RED("animFeatureIndex")]
        public CInt32 AnimFeatureIndex
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("localizedType")]
        public gamedataLocKeyWrapper LocalizedType
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
    }
}
