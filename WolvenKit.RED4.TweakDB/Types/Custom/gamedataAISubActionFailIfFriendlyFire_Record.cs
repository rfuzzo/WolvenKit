namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionFailIfFriendlyFire_Record : gamedataTweakDBRecord
    {
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("checkOnlyFirstFrame")]
        public CBool CheckOnlyFirstFrame
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
