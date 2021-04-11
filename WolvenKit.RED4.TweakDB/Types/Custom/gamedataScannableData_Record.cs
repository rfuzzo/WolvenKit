namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataScannableData_Record : gamedataTweakDBRecord
    {
        [RED("revealOrder")]
        public CInt32 RevealOrder
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("localizedDescription")]
        public gamedataLocKeyWrapper LocalizedDescription
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("iconName")]
        public CName IconName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("localizedName")]
        public gamedataLocKeyWrapper LocalizedName
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("friendlyName")]
        public CString FriendlyName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("iconRecord")]
        public TweakDBID IconRecord
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
