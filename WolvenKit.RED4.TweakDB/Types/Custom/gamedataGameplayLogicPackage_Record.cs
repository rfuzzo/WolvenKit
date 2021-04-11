namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataGameplayLogicPackage_Record : gamedataTweakDBRecord
    {
        [RED("duration")]
        public TweakDBID Duration
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("effectors")]
        public CArray<TweakDBID> Effectors
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("stats")]
        public CArray<TweakDBID> Stats
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("UIData")]
        public TweakDBID UIData
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("statPools")]
        public CArray<TweakDBID> StatPools
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("prereq")]
        public CName Prereq
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("stackable")]
        public CBool Stackable
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("animationWrapperOverrides")]
        public CArray<CName> AnimationWrapperOverrides
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("items")]
        public CArray<TweakDBID> Items
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
