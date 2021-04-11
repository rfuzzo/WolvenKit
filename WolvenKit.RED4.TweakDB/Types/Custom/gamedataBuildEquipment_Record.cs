namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataBuildEquipment_Record : gamedataTweakDBRecord
    {
        [RED("equipment")]
        public TweakDBID Equipment
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
