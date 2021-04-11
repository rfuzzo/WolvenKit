namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleFxCollisionMaterial_Record : gamedataTweakDBRecord
    {
        [RED("scratch_decal")]
        public raRef<CResource> Scratch_decal
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("impact_particles")]
        public raRef<CResource> Impact_particles
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
        
        [RED("scratch_particles")]
        public raRef<CResource> Scratch_particles
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("impact_decal")]
        public raRef<CResource> Impact_decal
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
    }
}
