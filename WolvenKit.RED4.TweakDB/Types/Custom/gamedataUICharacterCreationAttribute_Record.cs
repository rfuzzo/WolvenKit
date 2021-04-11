namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataUICharacterCreationAttribute_Record : gamedataTweakDBRecord
    {
        [RED("value")]
        public CFloat Value
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("shortcut")]
        public CString Shortcut
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("attribute")]
        public TweakDBID Attribute
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("iconPath")]
        public CName IconPath
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("description")]
        public CString Description
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
