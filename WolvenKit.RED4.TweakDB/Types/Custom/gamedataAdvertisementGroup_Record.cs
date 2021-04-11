namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAdvertisementGroup_Record : gamedataTweakDBRecord
    {
        [RED("includedGroups")]
        public CArray<TweakDBID> IncludedGroups
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("fallbackAtlasResource")]
        public raRef<CResource> FallbackAtlasResource
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("lightTintColor")]
        public Vector3 LightTintColor
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("advertisements")]
        public CArray<TweakDBID> Advertisements
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("advertTintColor")]
        public Vector3 AdvertTintColor
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
    }
}
