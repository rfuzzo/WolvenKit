namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataStatsList_Record : gamedataTweakDBRecord
    {
        [RED("stats")]
        public CArray<TweakDBID> Stats
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
