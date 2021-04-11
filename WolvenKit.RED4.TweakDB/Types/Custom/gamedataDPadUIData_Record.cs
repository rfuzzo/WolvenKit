namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataDPadUIData_Record : gamedataTweakDBRecord
    {
        [RED("restrictionTags")]
        public CArray<CName> RestrictionTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
    }
}
