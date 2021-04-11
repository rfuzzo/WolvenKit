namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataActionMapField_Record : gamedataTweakDBRecord
    {
        [RED("itemType")]
        public TweakDBID ItemType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("map")]
        public TweakDBID Map
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
