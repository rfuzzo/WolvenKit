namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPoolValueModifier_Record : gamedataTweakDBRecord
    {
        [RED("rangeEnd")]
        public CFloat RangeEnd
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("delayOnChange")]
        public CBool DelayOnChange
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("usingPointValues")]
        public CBool UsingPointValues
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("startDelay")]
        public CFloat StartDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("valuePerSec")]
        public CFloat ValuePerSec
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("rangeBegin")]
        public CFloat RangeBegin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("enabled")]
        public CBool Enabled
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
