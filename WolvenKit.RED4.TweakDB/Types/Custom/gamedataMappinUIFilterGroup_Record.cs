namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMappinUIFilterGroup_Record : gamedataTweakDBRecord
    {
        [RED("mappins")]
        public CArray<TweakDBID> Mappins
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("widgetState")]
        public CName WidgetState
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("filterType")]
        public TweakDBID FilterType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("shouldCollectMappins")]
        public CBool ShouldCollectMappins
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
