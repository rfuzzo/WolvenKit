namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionWorkspot_Record : gamedataTweakDBRecord
    {
        [RED("workspotObject")]
        public TweakDBID WorkspotObject
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
