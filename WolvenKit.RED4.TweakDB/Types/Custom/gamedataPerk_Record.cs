namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPerk_Record : gamedataTweakDBRecord
    {
        [RED("proficiency")]
        public TweakDBID Proficiency
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("curve")]
        public TweakDBID Curve
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("binkPath")]
        public raRef<CResource> BinkPath
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("loc_name_key")]
        public CString Loc_name_key
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("utility")]
        public TweakDBID Utility
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("enumComment")]
        public CString EnumComment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("levels")]
        public CArray<TweakDBID> Levels
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("displayName")]
        public CString DisplayName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("loc_desc_key")]
        public CString Loc_desc_key
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("iconPath")]
        public CName IconPath
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
