namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataChatterHelperRadius_Record : gamedataTweakDBRecord
    {
        [RED("maxDistanceToOtherPlayer")]
        public CFloat MaxDistanceToOtherPlayer
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minDistanceToOtherPlayer")]
        public CFloat MinDistanceToOtherPlayer
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
