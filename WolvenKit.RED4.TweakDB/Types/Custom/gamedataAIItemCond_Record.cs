namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIItemCond_Record : gamedataTweakDBRecord
    {
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("checkAllItemsInEquipmentGroup")]
        public CBool CheckAllItemsInEquipmentGroup
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("evolution")]
        public TweakDBID Evolution
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("itemID")]
        public TweakDBID ItemID
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("itemCategory")]
        public TweakDBID ItemCategory
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("itemType")]
        public TweakDBID ItemType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("itemTag")]
        public CName ItemTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("equipmentGroup")]
        public CName EquipmentGroup
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("triggerModes")]
        public CArray<TweakDBID> TriggerModes
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
