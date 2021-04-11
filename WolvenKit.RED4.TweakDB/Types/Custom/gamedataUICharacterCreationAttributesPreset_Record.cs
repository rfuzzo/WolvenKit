namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataUICharacterCreationAttributesPreset_Record : gamedataTweakDBRecord
    {
        [RED("attributes")]
        public CArray<TweakDBID> Attributes
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
