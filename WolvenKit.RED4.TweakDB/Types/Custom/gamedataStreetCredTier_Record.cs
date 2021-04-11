namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataStreetCredTier_Record : gamedataTweakDBRecord
    {
        [RED("streetCredRequirement")]
        public CInt32 StreetCredRequirement
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
