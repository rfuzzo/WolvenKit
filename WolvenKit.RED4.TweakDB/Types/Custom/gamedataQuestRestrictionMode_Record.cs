namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataQuestRestrictionMode_Record : gamedataTweakDBRecord
    {
        [RED("InjectedActions")]
        public CArray<CName> InjectedActions
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
    }
}
