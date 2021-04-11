namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAttachmentSlot_Record : gamedataTweakDBRecord
    {
        [RED("unlockedBy")]
        public CString UnlockedBy
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("localizedName")]
        public CString LocalizedName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("tagsForActiveItemCycling")]
        public CArray<CName> TagsForActiveItemCycling
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("entitySlotName")]
        public CString EntitySlotName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("customOffset")]
        public Vector3 CustomOffset
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
    }
}
