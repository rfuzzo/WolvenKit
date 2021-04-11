namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIOptimalDistanceCond_Record : gamedataTweakDBRecord
    {
        [RED("distanceMult")]
        public CFloat DistanceMult
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("failWhenFurtherThantCurrentRing")]
        public CBool FailWhenFurtherThantCurrentRing
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("source")]
        public TweakDBID Source
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("predictionTime")]
        public CFloat PredictionTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("checkRings")]
        public CArray<TweakDBID> CheckRings
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("toleranceOffset")]
        public CFloat ToleranceOffset
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("failWhenCloserThanCurrentRing")]
        public CBool FailWhenCloserThanCurrentRing
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("toleranceMult")]
        public CFloat ToleranceMult
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("distanceOffset")]
        public CFloat DistanceOffset
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
