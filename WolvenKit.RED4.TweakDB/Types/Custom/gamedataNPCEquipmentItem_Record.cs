namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataNPCEquipmentItem_Record : gamedataNPCEquipmentGroupEntry_Record
    {
        [RED("onBodySlot")]
        public TweakDBID OnBodySlot
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
        
        [RED("unequipCondition")]
        public CArray<TweakDBID> UnequipCondition
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("equipCondition")]
        public CArray<TweakDBID> EquipCondition
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("equipSlot")]
        public TweakDBID EquipSlot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
