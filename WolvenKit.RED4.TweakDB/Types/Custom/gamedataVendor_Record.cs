namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVendor_Record : gamedataTweakDBRecord
    {
        [RED("inGameTimeToRestock")]
        public CFloat InGameTimeToRestock
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("craftbooks")]
        public CArray<TweakDBID> Craftbooks
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("vendorType")]
        public TweakDBID VendorType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("vendorFilterTags")]
        public CArray<CName> VendorFilterTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("itemStock")]
        public CArray<TweakDBID> ItemStock
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("vendorInverseFilterTags")]
        public CArray<CName> VendorInverseFilterTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("experienceStock")]
        public CArray<TweakDBID> ExperienceStock
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("faction")]
        public TweakDBID Faction
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("customerInverseFilterTags")]
        public CArray<CName> CustomerInverseFilterTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("customerFilterTags")]
        public CArray<CName> CustomerFilterTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("localizedDescription")]
        public CString LocalizedDescription
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("accessPrereqs")]
        public CArray<TweakDBID> AccessPrereqs
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("mapVisibilityPrereqs")]
        public CArray<TweakDBID> MapVisibilityPrereqs
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("localizedName")]
        public CString LocalizedName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
