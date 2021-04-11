namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionActivateLightPreset_Record : gamedataTweakDBRecord
    {
        [RED("lightPreset")]
        public TweakDBID LightPreset
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
