namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionSetUnequipSecondaryWeapons_Record : gamedataTweakDBRecord
    {
        [RED("animationTime")]
        public CFloat AnimationTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("dropItem")]
        public CBool DropItem
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
