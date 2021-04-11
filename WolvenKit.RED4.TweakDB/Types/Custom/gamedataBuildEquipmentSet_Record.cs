namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataBuildEquipmentSet_Record : gamedataTweakDBRecord
    {
        [RED("equipment")]
        public CArray<TweakDBID> Equipment
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
