namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataLandingFxMaterial_Record : gamedataTweakDBRecord
    {
        [RED("material")]
        public TweakDBID Material
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("effect")]
        public raRef<CResource> Effect
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
    }
}
