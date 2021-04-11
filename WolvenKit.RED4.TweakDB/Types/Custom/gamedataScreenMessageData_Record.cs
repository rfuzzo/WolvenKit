namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataScreenMessageData_Record : gamedataTweakDBRecord
    {
        [RED("textVerticalAlignment")]
        public CName TextVerticalAlignment
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
        
        [RED("fontPath")]
        public CString FontPath
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("friendlyName")]
        public CString FriendlyName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("rightMargin")]
        public CFloat RightMargin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("autoScroll")]
        public CBool AutoScroll
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("topMargin")]
        public CFloat TopMargin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("backgroundOpacity")]
        public CFloat BackgroundOpacity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("leftMargin")]
        public CFloat LeftMargin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("textColor")]
        public CArray<CInt32> TextColor
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("textHorizontalAlignment")]
        public CName TextHorizontalAlignment
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("backgroundTextureID")]
        public TweakDBID BackgroundTextureID
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("bottomMargin")]
        public CFloat BottomMargin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("messageGroup")]
        public TweakDBID MessageGroup
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("fontStyle")]
        public CName FontStyle
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("scrollSpeed")]
        public CFloat ScrollSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("fontSize")]
        public CInt32 FontSize
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("backgroundColor")]
        public CArray<CInt32> BackgroundColor
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("localizedDescription")]
        public gamedataLocKeyWrapper LocalizedDescription
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
    }
}
