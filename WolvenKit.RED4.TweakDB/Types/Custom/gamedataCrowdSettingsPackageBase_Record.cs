namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCrowdSettingsPackageBase_Record : gamedataTweakDBRecord
    {
        [RED("specs")]
        public CArray<TweakDBID> Specs
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
