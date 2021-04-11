namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIDirectorSchedulePlan_Record : gamedataTweakDBRecord
    {
        [RED("MinTensionToPerform")]
        public CFloat MinTensionToPerform
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spawningDesc")]
        public TweakDBID SpawningDesc
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
