namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataSquadBackyardBase_Record : gamedataTweakDBRecord
    {
        [RED("paddingFrom")]
        public CFloat PaddingFrom
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("paddingTo")]
        public CFloat PaddingTo
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
