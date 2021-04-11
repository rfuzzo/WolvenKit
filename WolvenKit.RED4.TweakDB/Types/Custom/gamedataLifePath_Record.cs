namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataLifePath_Record : gamedataTweakDBRecord
    {
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
        
        [RED("captionIcon")]
        public TweakDBID CaptionIcon
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("displayName")]
        public gamedataLocKeyWrapper DisplayName
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("newGameSpawnTag")]
        public CName NewGameSpawnTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
