namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRangedAttack_Record : gamedataTweakDBRecord
    {
        [RED("hitCooldown")]
        public CFloat HitCooldown
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("explosionAttack")]
        public CName ExplosionAttack
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("NPCTimeDilated")]
        public TweakDBID NPCTimeDilated
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("playerAttack")]
        public TweakDBID PlayerAttack
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("NPCAttack")]
        public TweakDBID NPCAttack
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("playerTimeDilated")]
        public TweakDBID PlayerTimeDilated
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
