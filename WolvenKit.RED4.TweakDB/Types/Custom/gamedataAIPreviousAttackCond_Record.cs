namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIPreviousAttackCond_Record : gamedataTweakDBRecord
    {
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("previousAttackName")]
        public CArray<CName> PreviousAttackName
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("timeWindow")]
        public CFloat TimeWindow
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
