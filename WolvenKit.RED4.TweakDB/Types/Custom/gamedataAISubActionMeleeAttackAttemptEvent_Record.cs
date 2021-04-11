namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionMeleeAttackAttemptEvent_Record : gamedataTweakDBRecord
    {
        [RED("isWindUp")]
        public CBool IsWindUp
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
