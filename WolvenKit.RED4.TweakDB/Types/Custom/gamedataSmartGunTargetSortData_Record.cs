namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataSmartGunTargetSortData_Record : gamedataTweakDBRecord
    {
        [RED("previouslyLockedBonusSq")]
        public CFloat PreviouslyLockedBonusSq
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("worldProximityBonusSq")]
        public CFloat WorldProximityBonusSq
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("angleDistUnitWeightSq")]
        public CFloat AngleDistUnitWeightSq
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("worldDistUnitWeightSq")]
        public CFloat WorldDistUnitWeightSq
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("angleProximityBonusSq")]
        public CFloat AngleProximityBonusSq
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("angleProximityThresholdSq")]
        public CFloat AngleProximityThresholdSq
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("angleDistUnitSq")]
        public CFloat AngleDistUnitSq
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("worldDistUnitSq")]
        public CFloat WorldDistUnitSq
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("worldProximityThresholdSq")]
        public CFloat WorldProximityThresholdSq
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
