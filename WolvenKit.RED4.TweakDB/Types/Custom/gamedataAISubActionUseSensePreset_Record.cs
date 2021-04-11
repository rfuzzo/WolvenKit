namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionUseSensePreset_Record : gamedataTweakDBRecord
    {
        [RED("sensePreset")]
        public TweakDBID SensePreset
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
