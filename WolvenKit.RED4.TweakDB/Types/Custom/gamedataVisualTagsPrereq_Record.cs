namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVisualTagsPrereq_Record : gamedataIPrereq_Record
    {
        [RED("allowedTags")]
        public CArray<CName> AllowedTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
