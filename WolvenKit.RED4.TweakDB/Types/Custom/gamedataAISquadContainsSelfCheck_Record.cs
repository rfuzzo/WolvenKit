namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISquadContainsSelfCheck_Record : gamedataTweakDBRecord
    {
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("optionalFastExit")]
        public CBool OptionalFastExit
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
