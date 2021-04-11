namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataStatusEffectFX_Record : gamedataTweakDBRecord
    {
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("shouldReapply")]
        public CBool ShouldReapply
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
