namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMovementParams_Record : gamedataTweakDBRecord
    {
        [RED("params")]
        public CArray<TweakDBID> Params
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
