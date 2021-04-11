namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionEquipOnSlot_Record : gamedataTweakDBRecord
    {
        [RED("useItemSpawnDelayFromWeapon")]
        public CBool UseItemSpawnDelayFromWeapon
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("animationTime")]
        public CFloat AnimationTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
