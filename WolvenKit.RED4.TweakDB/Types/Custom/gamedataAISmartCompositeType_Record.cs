namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISmartCompositeType_Record : gamedataTweakDBRecord
    {
        [RED("randomizeIteratorOnReset")]
        public CBool RandomizeIteratorOnReset
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("hasMemory")]
        public CBool HasMemory
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("incrementIteratorOnDeactivation")]
        public CBool IncrementIteratorOnDeactivation
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("enumComment")]
        public CString EnumComment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
