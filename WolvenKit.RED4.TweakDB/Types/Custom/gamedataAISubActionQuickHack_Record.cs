namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionQuickHack_Record : gamedataTweakDBRecord
    {
        [RED("actionResult")]
        public TweakDBID ActionResult
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("pauseUploadCondition")]
        public CArray<TweakDBID> PauseUploadCondition
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("establishContactOnly")]
        public CBool EstablishContactOnly
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
