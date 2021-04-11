namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleDestructionPointDamper_Record : gamedataTweakDBRecord
    {
        [RED("dampValue")]
        public CFloat DampValue
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("pointFragility")]
        public CFloat PointFragility
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("pointIndex")]
        public CInt32 PointIndex
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
