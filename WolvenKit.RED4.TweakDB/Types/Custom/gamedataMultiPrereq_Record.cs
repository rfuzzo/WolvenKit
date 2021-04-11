namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMultiPrereq_Record : gamedataTweakDBRecord
    {
        [RED("nestedPrereqs")]
        public CArray<TweakDBID> NestedPrereqs
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("aggregationType")]
        public CName AggregationType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("prereqClassName")]
        public CName PrereqClassName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
