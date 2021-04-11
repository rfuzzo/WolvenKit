namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionReloadWeapon_Record : gamedataTweakDBRecord
    {
        [RED("pauseCondition")]
        public CArray<TweakDBID> PauseCondition
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("duration")]
        public CFloat Duration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("weaponSlot")]
        public TweakDBID WeaponSlot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
