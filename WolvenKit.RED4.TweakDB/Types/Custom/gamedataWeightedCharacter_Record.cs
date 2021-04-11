namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataWeightedCharacter_Record : gamedataTweakDBRecord
    {
        [RED("character")]
        public TweakDBID Character
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
