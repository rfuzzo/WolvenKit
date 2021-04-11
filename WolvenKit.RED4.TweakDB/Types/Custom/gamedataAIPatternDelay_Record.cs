namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIPatternDelay_Record : gamedataTweakDBRecord
    {
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("shotNumber")]
        public CInt32 ShotNumber
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
