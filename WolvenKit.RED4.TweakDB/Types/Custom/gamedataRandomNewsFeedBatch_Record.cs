namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRandomNewsFeedBatch_Record : gamedataTweakDBRecord
    {
        [RED("feedList")]
        public CArray<CName> FeedList
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
    }
}
