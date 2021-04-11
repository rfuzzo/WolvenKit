namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataChoiceCaptionIconPart_Record : gamedataTweakDBRecord
    {
        [RED("texturePartID")]
        public TweakDBID TexturePartID
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("comment")]
        public CString Comment
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
        
        [RED("partType")]
        public TweakDBID PartType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("mappinVariant")]
        public TweakDBID MappinVariant
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
