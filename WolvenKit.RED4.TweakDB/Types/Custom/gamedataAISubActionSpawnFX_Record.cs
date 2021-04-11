namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionSpawnFX_Record : gamedataTweakDBRecord
    {
        [RED("attachmentSlot")]
        public TweakDBID AttachmentSlot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
