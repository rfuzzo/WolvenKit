namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataObjectActionPrereq_Record : gamedataTweakDBRecord
    {
        [RED("failureExplanation")]
        public CString FailureExplanation
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("failureConditionPrereq")]
        public CArray<TweakDBID> FailureConditionPrereq
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
