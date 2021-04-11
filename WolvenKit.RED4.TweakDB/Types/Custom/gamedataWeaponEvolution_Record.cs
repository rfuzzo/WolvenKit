namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataWeaponEvolution_Record : gamedataTweakDBRecord
    {
        [RED("name")]
        public CString Name
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
