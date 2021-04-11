namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIActionAnimData_Record : gamedataTweakDBRecord
    {
        [RED("weaponOverride")]
        public CInt32 WeaponOverride
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("updateMovePolicy")]
        public CBool UpdateMovePolicy
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("ragdollOnDeath")]
        public CBool RagdollOnDeath
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("animSlot")]
        public TweakDBID AnimSlot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("animVariation")]
        public CInt32 AnimVariation
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("animVariationSubAction")]
        public TweakDBID AnimVariationSubAction
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("animFeature")]
        public CName AnimFeature
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("direction")]
        public TweakDBID Direction
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
