namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataDistrict_Record : gamedataTweakDBRecord
    {
        [RED("isQuestDistrict")]
        public CBool IsQuestDistrict
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("explosiveDeviceStimRangeMultiplier")]
        public CFloat ExplosiveDeviceStimRangeMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("enumName")]
        public CString EnumName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("preventionPreset")]
        public TweakDBID PreventionPreset
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("uiIcon")]
        public CName UiIcon
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("uiState")]
        public CName UiState
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("gunShotStimRange")]
        public CFloat GunShotStimRange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("parentDistrict")]
        public TweakDBID ParentDistrict
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("enumComment")]
        public CString EnumComment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("localizedName")]
        public CString LocalizedName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("gangs")]
        public CArray<TweakDBID> Gangs
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
