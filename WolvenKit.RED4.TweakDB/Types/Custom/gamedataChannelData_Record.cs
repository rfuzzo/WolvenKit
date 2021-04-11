namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataChannelData_Record : gamedataTweakDBRecord
    {
        [RED("channelWidget")]
        public CName ChannelWidget
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("orderID")]
        public CInt32 OrderID
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("localizedName")]
        public CString LocalizedName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("audioEvent")]
        public CName AudioEvent
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("dynamicTexturePath")]
        public CString DynamicTexturePath
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("overlayWidgetPath")]
        public CString OverlayWidgetPath
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
