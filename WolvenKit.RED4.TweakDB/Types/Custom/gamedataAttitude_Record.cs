namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAttitude_Record : gamedataTweakDBRecord
    {
        [RED("group2")]
        public TweakDBID Group2
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("group1")]
        public TweakDBID Group1
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("value")]
        public CString Value
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
