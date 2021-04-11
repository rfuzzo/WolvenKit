namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataHitPrereq_Record : gamedataTweakDBRecord
    {
        [RED("hitFlag")]
        public CString HitFlag
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("conditions")]
        public CArray<TweakDBID> Conditions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("pipelineStage")]
        public CString PipelineStage
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("isSynchronous")]
        public CBool IsSynchronous
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("callbackType")]
        public CString CallbackType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("prereqClassName")]
        public CName PrereqClassName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
