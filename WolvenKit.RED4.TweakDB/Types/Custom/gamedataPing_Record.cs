namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPing_Record : gamedataTweakDBRecord
    {
        [RED("minimapIconName")]
        public CName MinimapIconName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("lifeSpan")]
        public CFloat LifeSpan
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxCount")]
        public CInt32 MaxCount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("voTriggerName")]
        public CName VoTriggerName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("worldIconName")]
        public CName WorldIconName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
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
    }
}
