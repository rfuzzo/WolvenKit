namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataTrait_Record : gamedataTweakDBRecord
    {
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("requirement")]
        public TweakDBID Requirement
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("loc_name_key")]
        public CString Loc_name_key
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
        
        [RED("infiniteTraitData")]
        public TweakDBID InfiniteTraitData
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
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
        
        [RED("baseTraitData")]
        public TweakDBID BaseTraitData
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
