namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataOffMeshLinkTag_Record : gamedataTweakDBRecord
    {
        [RED("prerequisites")]
        public CArray<TweakDBID> Prerequisites
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("isAllowed")]
        public CBool IsAllowed
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("tag")]
        public CName Tag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
