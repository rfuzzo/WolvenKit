namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataSpawnableObject_Record : gamedataBaseObject_Record
    {
        [RED("visualTags")]
        public CArray<CName> VisualTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("multiplayerTemplatePaths")]
        public CArray<raRef<CResource>> MultiplayerTemplatePaths
        {
            get => GetProperty<CArray<raRef<CResource>>>();
            set => SetProperty<CArray<raRef<CResource>>>(value);
        }
        
        [RED("entityTemplatePath")]
        public raRef<CResource> EntityTemplatePath
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("priority")]
        public TweakDBID Priority
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("tags")]
        public CArray<CName> Tags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("persistentName")]
        public CName PersistentName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("appearanceName")]
        public CName AppearanceName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
