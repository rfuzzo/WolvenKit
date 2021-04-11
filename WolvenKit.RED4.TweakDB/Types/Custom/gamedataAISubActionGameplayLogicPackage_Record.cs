namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionGameplayLogicPackage_Record : gamedataTweakDBRecord
    {
        [RED("packages")]
        public CArray<TweakDBID> Packages
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
