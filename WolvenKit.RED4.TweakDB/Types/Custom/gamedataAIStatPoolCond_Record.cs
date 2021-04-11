namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIStatPoolCond_Record : gamedataTweakDBRecord
    {
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("statPool")]
        public TweakDBID StatPool
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("percentage")]
        public Vector2 Percentage
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("isIncreasing")]
        public CInt32 IsIncreasing
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
