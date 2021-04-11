namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPresetMapper_Record : gamedataTweakDBRecord
    {
        [RED("mappingName")]
        public CString MappingName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("preset")]
        public TweakDBID Preset
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
