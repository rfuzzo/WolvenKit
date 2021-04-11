namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVendorExperience_Record : gamedataTweakDBRecord
    {
        [RED("forceQuality")]
        public CName ForceQuality
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("quantity")]
        public CArray<TweakDBID> Quantity
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("pricePerPoint")]
        public CArray<TweakDBID> PricePerPoint
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("availabilityPrereq")]
        public TweakDBID AvailabilityPrereq
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("generationPrereqs")]
        public CArray<TweakDBID> GenerationPrereqs
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("proficiency")]
        public TweakDBID Proficiency
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
