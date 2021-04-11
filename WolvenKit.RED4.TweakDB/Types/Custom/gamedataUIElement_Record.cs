namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataUIElement_Record : gamedataTweakDBRecord
    {
        [RED("customConditions")]
        public CArray<TweakDBID> CustomConditions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
