namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRangedAttackPackage_Record : gamedataTweakDBRecord
    {
        [RED("chargeFire")]
        public TweakDBID ChargeFire
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("defaultFire")]
        public TweakDBID DefaultFire
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
