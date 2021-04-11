namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataBuildCyberwareSet_Record : gamedataTweakDBRecord
    {
        [RED("cyberware")]
        public CArray<TweakDBID> Cyberware
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
