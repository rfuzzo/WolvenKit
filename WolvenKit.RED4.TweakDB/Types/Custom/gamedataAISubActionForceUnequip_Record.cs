namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionForceUnequip_Record : gamedataTweakDBRecord
    {
        [RED("animationTime")]
        public CFloat AnimationTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("generateLootAfterDrop")]
        public CBool GenerateLootAfterDrop
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
        
        [RED("attachmentSlot")]
        public TweakDBID AttachmentSlot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("unequipDespiteInterruption")]
        public CBool UnequipDespiteInterruption
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("dropItem")]
        public CBool DropItem
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
