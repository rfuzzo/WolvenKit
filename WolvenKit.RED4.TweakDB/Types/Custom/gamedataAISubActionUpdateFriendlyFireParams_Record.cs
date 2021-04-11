namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionUpdateFriendlyFireParams_Record : gamedataTweakDBRecord
    {
        [RED("updateOnDeactivate")]
        public CBool UpdateOnDeactivate
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
