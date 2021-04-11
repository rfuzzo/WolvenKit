namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataStatPrereq_Record : gamedataTweakDBRecord
    {
        [RED("fireAndForget")]
        public CBool FireAndForget
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("prereqClassName")]
        public CName PrereqClassName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("statType")]
        public CName StatType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("comparisonType")]
        public CName ComparisonType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("valueToCheck")]
        public CFloat ValueToCheck
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
