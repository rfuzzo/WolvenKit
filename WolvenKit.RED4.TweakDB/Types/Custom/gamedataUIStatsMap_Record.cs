namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataUIStatsMap_Record : gamedataTweakDBRecord
    {
        [RED("primaryStats")]
        public CArray<TweakDBID> PrimaryStats
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("typesToCompareWith")]
        public CArray<TweakDBID> TypesToCompareWith
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("statsToCompare")]
        public CArray<TweakDBID> StatsToCompare
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("secondaryStats")]
        public CArray<TweakDBID> SecondaryStats
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
