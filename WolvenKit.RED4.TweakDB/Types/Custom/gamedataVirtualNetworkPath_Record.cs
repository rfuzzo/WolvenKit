namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVirtualNetworkPath_Record : gamedataTweakDBRecord
    {
        [RED("points")]
        public CArray<Vector3> Points
        {
            get => GetProperty<CArray<Vector3>>();
            set => SetProperty<CArray<Vector3>>(value);
        }
    }
}
