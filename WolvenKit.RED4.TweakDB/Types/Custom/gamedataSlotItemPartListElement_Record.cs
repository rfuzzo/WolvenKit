namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataSlotItemPartListElement_Record : gamedataTweakDBRecord
    {
        [RED("itemPartList")]
        public CArray<TweakDBID> ItemPartList
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("optionalProbabilityCurveName")]
        public CString OptionalProbabilityCurveName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("slot")]
        public TweakDBID Slot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
