namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIWeakSpotCond_Record : gamedataTweakDBRecord
    {
        [RED("weakspot")]
        public TweakDBID Weakspot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("includeDestroyed")]
        public CBool IncludeDestroyed
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
