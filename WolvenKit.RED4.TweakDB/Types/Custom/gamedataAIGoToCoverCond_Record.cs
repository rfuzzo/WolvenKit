namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIGoToCoverCond_Record : gamedataTweakDBRecord
    {
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
        
        [RED("desiredCover")]
        public TweakDBID DesiredCover
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("isCoverSelected")]
        public CInt32 IsCoverSelected
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("desiredCoverChanged")]
        public CInt32 DesiredCoverChanged
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("cover")]
        public TweakDBID Cover
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("isEnteringOrLeavingCover")]
        public CInt32 IsEnteringOrLeavingCover
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
