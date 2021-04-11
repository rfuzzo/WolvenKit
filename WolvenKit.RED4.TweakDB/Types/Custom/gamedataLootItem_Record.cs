namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataLootItem_Record : gamedataTweakDBRecord
    {
        [RED("dropChance")]
        public CFloat DropChance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("statModifiers")]
        public CArray<TweakDBID> StatModifiers
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("prereqID")]
        public TweakDBID PrereqID
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("itemID")]
        public TweakDBID ItemID
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("dropCountMax")]
        public CInt32 DropCountMax
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("dropCountMin")]
        public CInt32 DropCountMin
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
