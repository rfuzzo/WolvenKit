namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIIsInActiveCameraCond_Record : gamedataTweakDBRecord
    {
        [RED("radius")]
        public CFloat Radius
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
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("height")]
        public CFloat Height
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
