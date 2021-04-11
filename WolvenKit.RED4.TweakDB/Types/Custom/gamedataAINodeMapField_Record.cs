namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAINodeMapField_Record : gamedataTweakDBRecord
    {
        [RED("node")]
        public TweakDBID Node
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("forLOD")]
        public CInt32 ForLOD
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("isOverriddenBy")]
        public TweakDBID IsOverriddenBy
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
