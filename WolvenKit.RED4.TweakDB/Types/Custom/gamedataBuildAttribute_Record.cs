namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataBuildAttribute_Record : gamedataTweakDBRecord
    {
        [RED("attribute")]
        public TweakDBID Attribute
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("level")]
        public CInt32 Level
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
