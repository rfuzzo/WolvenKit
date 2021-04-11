namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMovementPolicyTagList_Record : gamedataTweakDBRecord
    {
        [RED("condition")]
        public TweakDBID Condition
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
    }
}
