namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataQuality_Record : gamedataTweakDBRecord
    {
        [RED("statModifier")]
        public TweakDBID StatModifier
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("name")]
        public CString Name
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("value")]
        public CInt32 Value
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
