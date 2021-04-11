namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataInteractionBase_Record : gamedataTweakDBRecord
    {
        [RED("tag")]
        public CName Tag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("caption")]
        public gamedataLocKeyWrapper Caption
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
        
        [RED("description")]
        public gamedataLocKeyWrapper Description
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("action")]
        public CString Action
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("name")]
        public CString Name
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("prereqID")]
        public CString PrereqID
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
