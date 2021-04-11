namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataGOGReward_Record : gamedataTweakDBRecord
    {
        [RED("displayName")]
        public gamedataLocKeyWrapper DisplayName
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }

        [RED("description")]
        public gamedataLocKeyWrapper Description
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }

        [RED("iconsAtlasSlot")]
        public CName IconsAtlasSlot
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }

        [RED("rewardToken")]
        public CInt32 RewardToken
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
