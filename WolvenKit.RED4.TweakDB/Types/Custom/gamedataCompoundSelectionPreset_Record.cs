namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCompoundSelectionPreset_Record : gamedataTweakDBRecord
    {
        [RED("gatherRadius")]
        public CFloat GatherRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("presets")]
        public CArray<CString> Presets
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
    }
}
