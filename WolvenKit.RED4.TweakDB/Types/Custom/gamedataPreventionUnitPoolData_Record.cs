namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPreventionUnitPoolData_Record : gamedataTweakDBRecord
    {
        [RED("characterRecord")]
        public TweakDBID CharacterRecord
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("weight")]
        public CFloat Weight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
