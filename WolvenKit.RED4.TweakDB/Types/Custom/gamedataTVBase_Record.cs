namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataTVBase_Record : gamedataDevice_Record
    {
        [RED("channels")]
        public CArray<TweakDBID> Channels
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
