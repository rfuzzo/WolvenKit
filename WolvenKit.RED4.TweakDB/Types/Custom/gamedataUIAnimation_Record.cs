namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataUIAnimation_Record : gamedataTweakDBRecord
    {
        [RED("animationName")]
        public CName AnimationName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("widgetResource")]
        public raRef<CResource> WidgetResource
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("loop")]
        public CBool Loop
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
