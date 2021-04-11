namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataLootTable_Record : gamedataTweakDBRecord
    {
        [RED("itemID")]
        public TweakDBID ItemID
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("minItemsToLoot")]
        public CInt32 MinItemsToLoot
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("lootTableInclusions")]
        public CArray<TweakDBID> LootTableInclusions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("queries")]
        public CArray<TweakDBID> Queries
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("lootGenerationType")]
        public CString LootGenerationType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("maxItemsToLoot")]
        public CInt32 MaxItemsToLoot
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("lootItems")]
        public CArray<TweakDBID> LootItems
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
