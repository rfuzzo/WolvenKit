namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVisionGroup_Record : gamedataTweakDBRecord
    {
        [RED("range")]
        public CFloat Range
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("groupName")]
        public CName GroupName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
