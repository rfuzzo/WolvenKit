namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIActionChangeNPCState_Record : gamedataTweakDBRecord
    {
        [RED("stanceState")]
        public CName StanceState
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("defenseMode")]
        public CName DefenseMode
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("locomotionMode")]
        public CName LocomotionMode
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("hitReactionMode")]
        public CName HitReactionMode
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("highLevelState")]
        public CName HighLevelState
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("upperBodyState")]
        public CName UpperBodyState
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
