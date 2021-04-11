namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIFriendlyFireCond_Record : gamedataTweakDBRecord
    {
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("checkPlayer")]
        public CBool CheckPlayer
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
