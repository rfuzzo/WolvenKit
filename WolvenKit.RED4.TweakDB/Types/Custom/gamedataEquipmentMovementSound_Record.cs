namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataEquipmentMovementSound_Record : gamedataTweakDBRecord
    {
        [RED("priority")]
        public CFloat Priority
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("audioMovementName")]
        public CName AudioMovementName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
