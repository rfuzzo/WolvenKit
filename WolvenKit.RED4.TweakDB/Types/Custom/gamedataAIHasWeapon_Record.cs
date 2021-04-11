namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIHasWeapon_Record : gamedataTweakDBRecord
    {
        [RED("itemTag")]
        public CName ItemTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("itemCategory")]
        public CArray<TweakDBID> ItemCategory
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("itemType")]
        public CArray<TweakDBID> ItemType
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
