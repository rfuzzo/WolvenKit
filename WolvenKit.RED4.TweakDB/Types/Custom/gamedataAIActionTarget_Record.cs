namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIActionTarget_Record : gamedataTweakDBRecord
    {
        [RED("isPosition")]
        public CBool IsPosition
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
        
        [RED("targetSlot")]
        public CName TargetSlot
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("trackingMode")]
        public TweakDBID TrackingMode
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("isCoverID")]
        public CBool IsCoverID
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
        
        [RED("behaviorArgumentName")]
        public CName BehaviorArgumentName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("isObject")]
        public CBool IsObject
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
