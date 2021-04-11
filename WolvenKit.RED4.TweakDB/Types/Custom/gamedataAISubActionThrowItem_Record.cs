namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionThrowItem_Record : gamedataTweakDBRecord
    {
        [RED("checkThrowQuery")]
        public CBool CheckThrowQuery
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("throwAngle")]
        public CFloat ThrowAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("positionPredictionTime")]
        public CFloat PositionPredictionTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("dropItemOnInterruption")]
        public CBool DropItemOnInterruption
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
        
        [RED("trajectoryGravity")]
        public CFloat TrajectoryGravity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("attachmentSlot")]
        public TweakDBID AttachmentSlot
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
        
        [RED("throwType")]
        public CName ThrowType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
