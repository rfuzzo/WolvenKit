namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMutablePoolValueModifier_Record : gamedataTweakDBRecord
    {
        [RED("valuePerSec")]
        public CFloat ValuePerSec
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("startDelayMods")]
        public CArray<TweakDBID> StartDelayMods
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("rangeEndMods")]
        public CArray<TweakDBID> RangeEndMods
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("valuePerSecMods")]
        public CArray<TweakDBID> ValuePerSecMods
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("delayOnChange")]
        public CBool DelayOnChange
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("rangeBeginMods")]
        public CArray<TweakDBID> RangeBeginMods
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("startDelay")]
        public CFloat StartDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("enabledMod")]
        public TweakDBID EnabledMod
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("rangeBegin")]
        public CFloat RangeBegin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("usingPointValues")]
        public CBool UsingPointValues
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("delayOnChangeMod")]
        public TweakDBID DelayOnChangeMod
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("rangeEnd")]
        public CFloat RangeEnd
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
