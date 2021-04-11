namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionFastExitWorkspot_Record : gamedataTweakDBRecord
    {
        [RED("destinationObj")]
        public TweakDBID DestinationObj
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("playSlowExitIfFailed")]
        public CBool PlaySlowExitIfFailed
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("stayInWorkspotIfFailed")]
        public CBool StayInWorkspotIfFailed
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
