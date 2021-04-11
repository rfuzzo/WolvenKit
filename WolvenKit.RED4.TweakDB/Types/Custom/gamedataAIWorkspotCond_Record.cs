namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIWorkspotCond_Record : gamedataAIActionSubCondition_Record
    {
        [RED("isInWorkspot")]
        public CInt32 IsInWorkspot
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("workspotObj")]
        public TweakDBID WorkspotObj
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
