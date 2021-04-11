namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISlotCond_Record : gamedataAIItemCond_Record
    {
        [RED("slot")]
        public TweakDBID Slot
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
        
        [RED("checkIfEmptySlotIsSpawningItem")]
        public CInt32 CheckIfEmptySlotIsSpawningItem
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("requestedTriggerModes")]
        public TweakDBID RequestedTriggerModes
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
