namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRewardSet_Record : gamedataTweakDBRecord
    {
        [RED("rewardItems")]
        public CArray<TweakDBID> RewardItems
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
