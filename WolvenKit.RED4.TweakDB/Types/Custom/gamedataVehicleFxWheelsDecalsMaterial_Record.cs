namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleFxWheelsDecalsMaterial_Record : gamedataTweakDBRecord
    {
        [RED("material")]
        public TweakDBID Material
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("tire_tracks_decal")]
        public raRef<CResource> Tire_tracks_decal
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("skid_marks_decal")]
        public raRef<CResource> Skid_marks_decal
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
    }
}
