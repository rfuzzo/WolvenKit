namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMappinUISettings_Record : gamedataMappinUIRuntimeProfile_Record
    {
        [RED("showInTier3")]
        public CBool ShowInTier3
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("completedPOIOpacity")]
        public CFloat CompletedPOIOpacity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
