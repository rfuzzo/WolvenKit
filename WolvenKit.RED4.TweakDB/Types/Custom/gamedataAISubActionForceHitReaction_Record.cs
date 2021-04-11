namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionForceHitReaction_Record : gamedataTweakDBRecord
    {
        [RED("hitBodyPart")]
        public CInt32 HitBodyPart
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("pauseCondition")]
        public CArray<TweakDBID> PauseCondition
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("hitIntensity")]
        public CInt32 HitIntensity
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("animVariation")]
        public CInt32 AnimVariation
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("hitType")]
        public CInt32 HitType
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("hitSource")]
        public CInt32 HitSource
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("hitDirection")]
        public CInt32 HitDirection
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("stance")]
        public CInt32 Stance
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
