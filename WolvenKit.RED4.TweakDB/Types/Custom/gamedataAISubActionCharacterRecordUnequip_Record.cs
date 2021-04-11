namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionCharacterRecordUnequip_Record : gamedataTweakDBRecord
    {
        [RED("dropItem")]
        public CBool DropItem
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
