namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleFxWheelsParticlesMaterial_Record : gamedataTweakDBRecord
    {
        [RED("skid_marks_particles")]
        public raRef<CResource> Skid_marks_particles
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("material")]
        public TweakDBID Material
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("tire_tracks_particles")]
        public raRef<CResource> Tire_tracks_particles
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
    }
}
