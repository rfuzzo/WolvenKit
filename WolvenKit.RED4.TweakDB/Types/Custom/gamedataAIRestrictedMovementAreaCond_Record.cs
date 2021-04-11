namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIRestrictedMovementAreaCond_Record : gamedataTweakDBRecord
    {
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
