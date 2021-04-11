namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataScreenMessagesList_Record : gamedataTweakDBRecord
    {
        [RED("messages")]
        public CArray<TweakDBID> Messages
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
