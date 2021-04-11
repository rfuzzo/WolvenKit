namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedatanpc_scanning_data_Record : gamedataTweakDBRecord
    {
        [RED("localizedName")]
        public gamedataLocKeyWrapper LocalizedName
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("localizedDescription")]
        public gamedataLocKeyWrapper LocalizedDescription
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("iconRecord")]
        public TweakDBID IconRecord
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("friendlyName")]
        public CString FriendlyName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("iconName")]
        public CName IconName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
