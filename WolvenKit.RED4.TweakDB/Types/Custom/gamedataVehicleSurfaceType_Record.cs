namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleSurfaceType_Record : gamedataTweakDBRecord
    {
        [RED("displayName")]
        public CString DisplayName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("materialNames")]
        public CArray<CName> MaterialNames
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
    }
}
