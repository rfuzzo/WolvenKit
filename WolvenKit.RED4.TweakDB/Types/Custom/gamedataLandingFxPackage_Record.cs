namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataLandingFxPackage_Record : gamedataTweakDBRecord
    {
        [RED("effect")]
        public raRef<CResource> Effect
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("materials")]
        public CArray<TweakDBID> Materials
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
