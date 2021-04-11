namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataBountyDrawTable_Record : gamedataTweakDBRecord
    {
        [RED("bountyChoices")]
        public CArray<TweakDBID> BountyChoices
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
