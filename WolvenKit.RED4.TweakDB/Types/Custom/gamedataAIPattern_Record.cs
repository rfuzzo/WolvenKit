namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIPattern_Record : gamedataTweakDBRecord
    {
        [RED("activationConditions")]
        public CArray<TweakDBID> ActivationConditions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("patternSize")]
        public CInt32 PatternSize
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("delays")]
        public CArray<TweakDBID> Delays
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
