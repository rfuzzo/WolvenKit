namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionUnequipOnSlot_Record : gamedataAISubActionCharacterRecordUnequip_Record
    {
        [RED("useItemSpawnDelayFromWeapon")]
        public CBool UseItemSpawnDelayFromWeapon
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
