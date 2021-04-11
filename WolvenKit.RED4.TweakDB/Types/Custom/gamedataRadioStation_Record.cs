namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRadioStation_Record : gamedataTweakDBRecord
    {
        [RED("index")]
        public CInt32 Index
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("icon")]
        public TweakDBID Icon
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
    }
}
