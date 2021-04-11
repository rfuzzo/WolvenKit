namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionCallSquadSearchBackUp_Record : gamedataTweakDBRecord
    {
        [RED("numberOfTargets")]
        public CFloat NumberOfTargets
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("callInLevel")]
        public CFloat CallInLevel
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
