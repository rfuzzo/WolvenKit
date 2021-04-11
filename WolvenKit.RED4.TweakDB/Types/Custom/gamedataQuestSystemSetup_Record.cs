namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataQuestSystemSetup_Record : gamedataTweakDBRecord
    {
        [RED("contentTokenSpawnMinCooldown")]
        public CFloat ContentTokenSpawnMinCooldown
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("customTooltipActions")]
        public CArray<CString> CustomTooltipActions
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("contentTokenSpawnMaxCooldown")]
        public CFloat ContentTokenSpawnMaxCooldown
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
