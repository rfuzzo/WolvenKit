namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPerkArea_Record : gamedataTweakDBRecord
    {
        [RED("masteryLevel")]
        public TweakDBID MasteryLevel
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("maxLevel")]
        public CInt32 MaxLevel
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("perks")]
        public CArray<TweakDBID> Perks
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("loc_name_key")]
        public CString Loc_name_key
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("curve")]
        public TweakDBID Curve
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("displayName")]
        public CString DisplayName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("loc_desc_key")]
        public CString Loc_desc_key
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("enumComment")]
        public CString EnumComment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("proficiency")]
        public TweakDBID Proficiency
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("requirement")]
        public TweakDBID Requirement
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("minLevel")]
        public CInt32 MinLevel
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
