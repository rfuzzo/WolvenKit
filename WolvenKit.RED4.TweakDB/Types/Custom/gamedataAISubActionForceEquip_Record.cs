namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionForceEquip_Record : gamedataTweakDBRecord
    {
        [RED("itemID")]
        public TweakDBID ItemID
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
        
        [RED("itemObject")]
        public TweakDBID ItemObject
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("animationTime")]
        public CFloat AnimationTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("itemTag")]
        public CName ItemTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("itemCategory")]
        public TweakDBID ItemCategory
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("attachmentSlot")]
        public TweakDBID AttachmentSlot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("equipDespiteInterruption")]
        public CBool EquipDespiteInterruption
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("itemType")]
        public TweakDBID ItemType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
