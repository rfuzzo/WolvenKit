namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataStatPoolUpdate_Record : gamedataTweakDBRecord
    {
        [RED("usePercent")]
        public CBool UsePercent
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("statPoolValue")]
        public CFloat StatPoolValue
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("statPoolType")]
        public TweakDBID StatPoolType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
