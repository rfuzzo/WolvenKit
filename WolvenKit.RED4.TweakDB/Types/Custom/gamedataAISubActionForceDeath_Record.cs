namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionForceDeath_Record : gamedataTweakDBRecord
    {
        [RED("hitDirection")]
        public CInt32 HitDirection
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("hitBodyPart")]
        public CInt32 HitBodyPart
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
        
        [RED("hitIntensity")]
        public CInt32 HitIntensity
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("hitSource")]
        public CInt32 HitSource
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
