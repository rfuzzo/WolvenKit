namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionActivateStrongArmsFX_Record : gamedataTweakDBRecord
    {
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
