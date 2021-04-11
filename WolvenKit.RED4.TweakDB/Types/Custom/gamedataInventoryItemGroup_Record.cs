namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataInventoryItemGroup_Record : gamedataTweakDBRecord
    {
        [RED("items")]
        public CArray<TweakDBID> Items
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
