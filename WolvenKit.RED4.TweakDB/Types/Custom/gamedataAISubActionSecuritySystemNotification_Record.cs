namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionSecuritySystemNotification_Record : gamedataTweakDBRecord
    {
        [RED("notificationType")]
        public TweakDBID NotificationType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("threat")]
        public TweakDBID Threat
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
