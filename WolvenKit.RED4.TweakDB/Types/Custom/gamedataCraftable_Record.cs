namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCraftable_Record : gamedataTweakDBRecord
    {
        [RED("craftableItem")]
        public CArray<TweakDBID> CraftableItem
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
