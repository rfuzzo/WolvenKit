namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAttitudeGroup_Record : gamedataTweakDBRecord
    {
        [RED("isState")]
        public CBool IsState
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("parent")]
        public TweakDBID Parent
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
