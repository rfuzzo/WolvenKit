namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataItemDropSettings_Record : gamedataTweakDBRecord
    {
        [RED("desiredInitialRotation")]
        public CFloat DesiredInitialRotation
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("desiredAngularVelocity")]
        public CFloat DesiredAngularVelocity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
