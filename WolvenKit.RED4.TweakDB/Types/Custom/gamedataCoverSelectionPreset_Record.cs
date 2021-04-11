namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCoverSelectionPreset_Record : gamedataTweakDBRecord
    {
        [RED("dismissedCoverTimer")]
        public CFloat DismissedCoverTimer
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("postFiltering")]
        public CArray<CString> PostFiltering
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("scoring")]
        public CArray<CString> Scoring
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("gatherRadius")]
        public CFloat GatherRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("usesLineOfSight")]
        public CBool UsesLineOfSight
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("filtering")]
        public CArray<CString> Filtering
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("combatRing")]
        public TweakDBID CombatRing
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
