namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataSlotItemPartPreset_Record : gamedataTweakDBRecord
    {
        [RED("itemPartList")]
        public CArray<TweakDBID> ItemPartList
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("slot")]
        public TweakDBID Slot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("itemPartPreset")]
        public TweakDBID ItemPartPreset
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
