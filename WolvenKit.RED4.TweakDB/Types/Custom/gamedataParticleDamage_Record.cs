namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataParticleDamage_Record : gamedataTweakDBRecord
    {
        [RED("particlePath")]
        public raRef<CResource> ParticlePath
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("attack")]
        public TweakDBID Attack
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("cooldown")]
        public CFloat Cooldown
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
