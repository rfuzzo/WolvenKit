namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionPlayVoiceOver_Record : gamedataTweakDBRecord
    {
        [RED("cooldown")]
        public TweakDBID Cooldown
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("repeat")]
        public CBool Repeat
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("setSelfAsAnsweringEntity")]
        public CBool SetSelfAsAnsweringEntity
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("sendEventToSquadmates")]
        public CBool SendEventToSquadmates
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("condition")]
        public TweakDBID Condition
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
