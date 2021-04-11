namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionTriggerItemActivation_Record : gamedataTweakDBRecord
    {
        [RED("instigator")]
        public TweakDBID Instigator
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
        
        [RED("attachmentSlot")]
        public TweakDBID AttachmentSlot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
