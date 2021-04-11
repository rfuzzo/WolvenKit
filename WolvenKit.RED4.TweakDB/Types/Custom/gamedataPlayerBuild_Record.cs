namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPlayerBuild_Record : gamedataTweakDBRecord
    {
        [RED("proficiencies")]
        public CArray<TweakDBID> Proficiencies
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("enumComment")]
        public CString EnumComment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("displayName")]
        public gamedataLocKeyWrapper DisplayName
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("captionIcon")]
        public TweakDBID CaptionIcon
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
