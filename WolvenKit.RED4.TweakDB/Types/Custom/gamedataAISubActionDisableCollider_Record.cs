namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionDisableCollider_Record : gamedataTweakDBRecord
    {
        [RED("disable")]
        public CBool Disable
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("enableOnDeactivate")]
        public CBool EnableOnDeactivate
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
