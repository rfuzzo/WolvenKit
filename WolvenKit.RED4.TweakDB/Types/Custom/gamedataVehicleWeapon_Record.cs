namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleWeapon_Record : gamedataTweakDBRecord
    {
        [RED("maxYaw")]
        public CFloat MaxYaw
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("wholeBurstProjectiles")]
        public CInt32 WholeBurstProjectiles
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("cycleTime")]
        public CFloat CycleTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("singleProjectileCycleTime")]
        public CFloat SingleProjectileCycleTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("genericShoot")]
        public CBool GenericShoot
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("canFiendlyFire")]
        public CBool CanFiendlyFire
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("minYaw")]
        public CFloat MinYaw
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minPitch")]
        public CFloat MinPitch
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("attackRange")]
        public CFloat AttackRange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("slot")]
        public TweakDBID Slot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("maxPitch")]
        public CFloat MaxPitch
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("weaponShootAnimEvent")]
        public CName WeaponShootAnimEvent
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("genericTick")]
        public CBool GenericTick
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("item")]
        public TweakDBID Item
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("singleShotProjectiles")]
        public CInt32 SingleShotProjectiles
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
