namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCodexRecord_Record : gamedataTweakDBRecord
    {
        [RED("unlockedFromStart")]
        public CBool UnlockedFromStart
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("tags")]
        public CArray<CName> Tags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("recordContent")]
        public CArray<TweakDBID> RecordContent
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("unlockPrereq")]
        public CName UnlockPrereq
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
