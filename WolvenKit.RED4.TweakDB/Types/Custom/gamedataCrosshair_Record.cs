namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCrosshair_Record : gamedataTweakDBRecord
    {
        [RED("widgetResourcePath")]
        public raRef<CResource> WidgetResourcePath
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
    }
}
