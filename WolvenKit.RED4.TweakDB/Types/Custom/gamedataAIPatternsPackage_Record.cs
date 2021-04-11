namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIPatternsPackage_Record : gamedataTweakDBRecord
    {
        [RED("patterns")]
        public CArray<TweakDBID> Patterns
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("activationConditions")]
        public CArray<TweakDBID> ActivationConditions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
