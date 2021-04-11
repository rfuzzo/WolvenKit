namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataSubCharacter_Record : gamedataCharacter_Record
    {
        [RED("humanoid")]
        public CBool Humanoid
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("isPrevention")]
        public CBool IsPrevention
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("enumComment")]
        public CString EnumComment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("referenceName")]
        public CName ReferenceName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("startingEquippedItems")]
        public CArray<TweakDBID> StartingEquippedItems
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
