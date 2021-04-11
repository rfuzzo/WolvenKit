namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataContentAssignment_Record : gamedataTweakDBRecord
    {
        [RED("upToCheck")]
        public CBool UpToCheck
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("overrideValue")]
        public CInt32 OverrideValue
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("questType")]
        public TweakDBID QuestType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("powerLevelMod")]
        public TweakDBID PowerLevelMod
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
