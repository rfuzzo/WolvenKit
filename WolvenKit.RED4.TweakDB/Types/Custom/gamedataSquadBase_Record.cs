namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataSquadBase_Record : gamedataTweakDBRecord
    {
        [RED("hasActiveAlley")]
        public CBool HasActiveAlley
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("defensiveBackyard")]
        public TweakDBID DefensiveBackyard
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("scriptHandler")]
        public CName ScriptHandler
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("offensiveLeftFence")]
        public TweakDBID OffensiveLeftFence
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("squadParams")]
        public CName SquadParams
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("offensiveBackyard")]
        public TweakDBID OffensiveBackyard
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("defensiveRightFence")]
        public TweakDBID DefensiveRightFence
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("offensiveRightFence")]
        public TweakDBID OffensiveRightFence
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("defensiveLeftFence")]
        public TweakDBID DefensiveLeftFence
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
