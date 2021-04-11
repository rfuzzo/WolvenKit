namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataNPCEquipmentItemPool_Record : gamedataTweakDBRecord
    {
        [RED("pool")]
        public CArray<TweakDBID> Pool
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
