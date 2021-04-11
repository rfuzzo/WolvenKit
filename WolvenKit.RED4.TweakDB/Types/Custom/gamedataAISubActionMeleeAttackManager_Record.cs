namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionMeleeAttackManager_Record : gamedataTweakDBRecord
    {
        [RED("spawnWeaponFX")]
        public CBool SpawnWeaponFX
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("sendFriendlyFireWarning")]
        public CBool SendFriendlyFireWarning
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("fxDelay")]
        public CFloat FxDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("trailDelay")]
        public CFloat TrailDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("trailDuration")]
        public CFloat TrailDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("warningDelay")]
        public CFloat WarningDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spawnTrail")]
        public CBool SpawnTrail
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
