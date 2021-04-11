namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataActionMap_Record : gamedataTweakDBRecord
    {
        [RED("defaultMap")]
        public TweakDBID DefaultMap
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("map")]
        public CArray<TweakDBID> Map
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
