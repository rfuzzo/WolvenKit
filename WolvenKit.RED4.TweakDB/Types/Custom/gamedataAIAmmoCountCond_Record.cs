namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIAmmoCountCond_Record : gamedataTweakDBRecord
    {
        [RED("percentage")]
        public Vector2 Percentage
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("max")]
        public CInt32 Max
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("min")]
        public CInt32 Min
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("weaponSlot")]
        public TweakDBID WeaponSlot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
