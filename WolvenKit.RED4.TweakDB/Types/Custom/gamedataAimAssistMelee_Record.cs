namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAimAssistMelee_Record : gamedataTweakDBRecord
    {
        [RED("aimSnapOnThrow")]
        public CBool AimSnapOnThrow
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("moveToTargetEnabledAttacks")]
        public CInt32 MoveToTargetEnabledAttacks
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("aimSnapOnAttack")]
        public CBool AimSnapOnAttack
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("aimSnapOnHit")]
        public CBool AimSnapOnHit
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("moveToTargetDistanceIntoAttackRange")]
        public CFloat MoveToTargetDistanceIntoAttackRange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("aimSnapOnBlockHit")]
        public CBool AimSnapOnBlockHit
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("moveToTargetSearchDistance")]
        public CFloat MoveToTargetSearchDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("aimSnapOnAim")]
        public CBool AimSnapOnAim
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
