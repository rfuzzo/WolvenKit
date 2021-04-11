namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionAttackWithWeapon_Record : gamedataTweakDBRecord
    {
        [RED("attackName")]
        public CName AttackName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("attack")]
        public TweakDBID Attack
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("attackTime")]
        public CFloat AttackTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("weaponSlots")]
        public CArray<TweakDBID> WeaponSlots
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("attackRange")]
        public CFloat AttackRange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("colliderBoxSize")]
        public Vector3 ColliderBoxSize
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("attackDuration")]
        public CFloat AttackDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
