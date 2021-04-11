namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataBuildProficiency_Record : gamedataTweakDBRecord
    {
        [RED("level")]
        public CInt32 Level
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("proficiency")]
        public TweakDBID Proficiency
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
