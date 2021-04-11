namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataWebsite_Record : gamedataTweakDBRecord
    {
        [RED("url")]
        public CString Url
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("widgetPath")]
        public raRef<CResource> WidgetPath
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
    }
}
