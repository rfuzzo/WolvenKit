namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIValidCoversCond_Record : gamedataTweakDBRecord
    {
        [RED("limitToRings")]
        public CArray<TweakDBID> LimitToRings
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("checkCurrentlyActiveRing")]
        public CBool CheckCurrentlyActiveRing
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("coversWithLOS")]
        public CInt32 CoversWithLOS
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
