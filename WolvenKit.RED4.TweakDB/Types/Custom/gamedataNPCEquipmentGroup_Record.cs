namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataNPCEquipmentGroup_Record : gamedataTweakDBRecord
    {
        [RED("equipmentItems")]
        public CArray<TweakDBID> EquipmentItems
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
