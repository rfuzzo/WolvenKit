namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataBuildPerkSet_Record : gamedataTweakDBRecord
    {
        [RED("perks")]
        public CArray<TweakDBID> Perks
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
