namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataUncontrolledMovementEffector_Record : gamedataEffector_Record
    {
        [RED("ragdollNoGroundThreshold")]
        public CFloat RagdollNoGroundThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("debugSourceName")]
        public CName DebugSourceName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("ragdollOnCollision")]
        public CBool RagdollOnCollision
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
