namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataNumberPlate_Record : gamedataTweakDBRecord
    {
        [RED("styleStateName")]
        public CName StyleStateName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("resource")]
        public raRef<CResource> Resource
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("message")]
        public TweakDBID Message
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("isUnique")]
        public CBool IsUnique
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
