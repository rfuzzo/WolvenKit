namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPassiveProficiencyBonus_Record : gamedataTweakDBRecord
    {
        [RED("uiData")]
        public TweakDBID UiData
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("statGroup")]
        public TweakDBID StatGroup
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("effectorToTrigger")]
        public TweakDBID EffectorToTrigger
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
