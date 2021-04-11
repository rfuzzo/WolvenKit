namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataBuildProficiencySet_Record : gamedataTweakDBRecord
    {
        [RED("proficiencies")]
        public CArray<TweakDBID> Proficiencies
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
