namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIDriverCond_Record : gamedataTweakDBRecord
    {
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("driver")]
        public TweakDBID Driver
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
