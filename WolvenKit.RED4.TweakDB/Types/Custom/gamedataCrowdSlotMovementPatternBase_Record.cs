namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCrowdSlotMovementPatternBase_Record : gamedataTweakDBRecord
    {
        [RED("settings")]
        public TweakDBID Settings
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
