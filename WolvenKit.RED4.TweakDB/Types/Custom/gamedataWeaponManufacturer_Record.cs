namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataWeaponManufacturer_Record : gamedataTweakDBRecord
    {
        [RED("name")]
        public CString Name
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
