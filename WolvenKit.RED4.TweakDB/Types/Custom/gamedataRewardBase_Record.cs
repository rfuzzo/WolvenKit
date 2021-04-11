namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRewardBase_Record : gamedataTweakDBRecord
    {
        [RED("contentAssignment")]
        public CName ContentAssignment
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("experience")]
        public CArray<TweakDBID> Experience
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("name")]
        public CString Name
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("recipes")]
        public CArray<TweakDBID> Recipes
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("items")]
        public CArray<TweakDBID> Items
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("statModifiers")]
        public CArray<TweakDBID> StatModifiers
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("currencyPackage")]
        public CArray<TweakDBID> CurrencyPackage
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("photoModeItem")]
        public CArray<TweakDBID> PhotoModeItem
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("achievement")]
        public CArray<TweakDBID> Achievement
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
