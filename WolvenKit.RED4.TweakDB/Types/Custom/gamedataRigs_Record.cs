namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRigs_Record : gamedataTweakDBRecord
    {
        [RED("rigsResRefs")]
        public CArray<raRef<CResource>> RigsResRefs
        {
            get => GetProperty<CArray<raRef<CResource>>>();
            set => SetProperty<CArray<raRef<CResource>>>(value);
        }
    }
}
