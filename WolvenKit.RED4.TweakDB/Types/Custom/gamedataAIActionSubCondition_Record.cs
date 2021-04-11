namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIActionSubCondition_Record : gamedataTweakDBRecord
    {
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
