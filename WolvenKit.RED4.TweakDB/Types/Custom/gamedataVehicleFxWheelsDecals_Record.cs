namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleFxWheelsDecals_Record : gamedataTweakDBRecord
    {
        [RED("smear_materials")]
        public CArray<TweakDBID> Smear_materials
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("materials")]
        public CArray<TweakDBID> Materials
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
