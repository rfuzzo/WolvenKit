namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAttack_GameEffect_Record : gamedataAttack_Record
    {
        [RED("explosionAttack")]
        public CName ExplosionAttack
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("damageBasedOnMissingHealthBonusMultiplier")]
        public CFloat DamageBasedOnMissingHealthBonusMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("nonEliteDamageBonusMultiplier")]
        public CFloat NonEliteDamageBonusMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("mechanicalDamageBonusMultiplier")]
        public CFloat MechanicalDamageBonusMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("hitCooldown")]
        public CFloat HitCooldown
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("attackTag")]
        public CName AttackTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("effectTag")]
        public CName EffectTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("audioAttackIndex")]
        public CFloat AudioAttackIndex
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("audioTag")]
        public CName AudioTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("effectName")]
        public CName EffectName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
