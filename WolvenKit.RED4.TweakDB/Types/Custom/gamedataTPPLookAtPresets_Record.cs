namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataTPPLookAtPresets_Record : gamedataTweakDBRecord
    {
        [RED("noWeaponPresets")]
        public CArray<TweakDBID> NoWeaponPresets
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("weaponReadyPresets")]
        public CArray<TweakDBID> WeaponReadyPresets
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("reloadPresets")]
        public CArray<TweakDBID> ReloadPresets
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("weaponSafePresets")]
        public CArray<TweakDBID> WeaponSafePresets
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
