namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMiniGame_Trap_Record : gamedataTweakDBRecord
    {
        [RED("spawnProbability")]
        public CFloat SpawnProbability
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("negativeTrap")]
        public CBool NegativeTrap
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("trapType")]
        public TweakDBID TrapType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("trapDescription")]
        public gamedataLocKeyWrapper TrapDescription
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("trapIcon")]
        public TweakDBID TrapIcon
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("trapName")]
        public gamedataLocKeyWrapper TrapName
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
    }
}
