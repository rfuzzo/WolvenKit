namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRandomPassengerEntry_Record : gamedataTweakDBRecord
    {
        [RED("probability")]
        public CFloat Probability
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("characterRecords")]
        public CArray<TweakDBID> CharacterRecords
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("role")]
        public CName Role
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("validSlotNames")]
        public CArray<CName> ValidSlotNames
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
    }
}
