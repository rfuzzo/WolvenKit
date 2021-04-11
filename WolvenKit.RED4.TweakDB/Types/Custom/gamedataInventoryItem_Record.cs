namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataInventoryItem_Record : gamedataTweakDBRecord
    {
        [RED("quantity")]
        public CInt32 Quantity
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("chanceInCrowd")]
        public CFloat ChanceInCrowd
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("equipSlot_DEPRECATED")]
        public TweakDBID EquipSlot_DEPRECATED
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("item")]
        public TweakDBID Item
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("activeForSlot")]
        public TweakDBID ActiveForSlot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
