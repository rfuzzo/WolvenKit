namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAimAssistConfigPreset_Record : gamedataTweakDBRecord
    {
        [RED("finishingParams")]
        public TweakDBID FinishingParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("magnetismParams")]
        public TweakDBID MagnetismParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("meleeParams")]
        public TweakDBID MeleeParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("bulletMagnetismParams")]
        public TweakDBID BulletMagnetismParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("aimSnapParams")]
        public TweakDBID AimSnapParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("commonParams")]
        public TweakDBID CommonParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
