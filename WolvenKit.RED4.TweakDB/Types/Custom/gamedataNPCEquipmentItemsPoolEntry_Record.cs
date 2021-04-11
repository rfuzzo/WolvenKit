namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataNPCEquipmentItemsPoolEntry_Record : gamedataTweakDBRecord
    {
        [RED("items")]
        public CArray<TweakDBID> Items
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("minLevel")]
        public CInt32 MinLevel
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("weight")]
        public CFloat Weight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
