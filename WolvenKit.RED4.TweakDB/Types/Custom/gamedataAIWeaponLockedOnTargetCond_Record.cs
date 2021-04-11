namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIWeaponLockedOnTargetCond_Record : gamedataTweakDBRecord
    {
        [RED("weaponSlot")]
        public TweakDBID WeaponSlot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
