namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataSquadFenceBase_Record : gamedataTweakDBRecord
    {
        [RED("paddingInnerFence")]
        public CFloat PaddingInnerFence
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("paddingOuterFence")]
        public CFloat PaddingOuterFence
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
