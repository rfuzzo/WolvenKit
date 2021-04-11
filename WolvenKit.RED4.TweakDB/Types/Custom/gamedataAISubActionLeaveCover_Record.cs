namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionLeaveCover_Record : gamedataTweakDBRecord
    {
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("checkExposure")]
        public CInt32 CheckExposure
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
