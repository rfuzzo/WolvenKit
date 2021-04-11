namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataStatPoolPrereq_Record : gamedataTweakDBRecord
    {
        [RED("valueToCheck")]
        public CFloat ValueToCheck
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("comparePercentage")]
        public CBool ComparePercentage
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("listenConstantly")]
        public CBool ListenConstantly
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("comparisonType")]
        public CName ComparisonType
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
        
        [RED("statPoolType")]
        public CName StatPoolType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("skipOnApply")]
        public CBool SkipOnApply
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
