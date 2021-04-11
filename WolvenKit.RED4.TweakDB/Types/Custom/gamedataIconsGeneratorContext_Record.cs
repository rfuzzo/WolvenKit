namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataIconsGeneratorContext_Record : gamedataTweakDBRecord
    {
        [RED("femalePlayerAnimSet")]
        public raRef<CResource> FemalePlayerAnimSet
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("malePlayerAnimSet")]
        public raRef<CResource> MalePlayerAnimSet
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
    }
}
