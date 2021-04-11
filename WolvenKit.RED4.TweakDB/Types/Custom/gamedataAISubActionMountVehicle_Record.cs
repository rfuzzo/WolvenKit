namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionMountVehicle_Record : gamedataTweakDBRecord
    {
        [RED("vehicle")]
        public TweakDBID Vehicle
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("mountInstantly")]
        public CBool MountInstantly
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("slot")]
        public TweakDBID Slot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
