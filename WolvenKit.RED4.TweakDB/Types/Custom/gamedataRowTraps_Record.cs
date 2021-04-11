namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRowTraps_Record : gamedataTweakDBRecord
    {
        [RED("traps")]
        public CArray<CInt32> Traps
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
    }
}
