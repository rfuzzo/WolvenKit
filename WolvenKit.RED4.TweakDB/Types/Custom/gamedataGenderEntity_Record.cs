namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataGenderEntity_Record : gamedataTweakDBRecord
    {
        [RED("gender")]
        public TweakDBID Gender
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("initial")]
        public CBool Initial
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("multiplayerEntities")]
        public CArray<raRef<CResource>> MultiplayerEntities
        {
            get => GetProperty<CArray<raRef<CResource>>>();
            set => SetProperty<CArray<raRef<CResource>>>(value);
        }
        
        [RED("entity")]
        public raRef<CResource> Entity
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
    }
}
