namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataWorldMapZoomLevel_Record : gamedataTweakDBRecord
    {
        [RED("rotation")]
        public EulerAngles Rotation
        {
            get => GetProperty<EulerAngles>();
            set => SetProperty<EulerAngles>(value);
        }
        
        [RED("fov")]
        public CFloat Fov
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("showDistricts")]
        public CBool ShowDistricts
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("canChangeFilters")]
        public CBool CanChangeFilters
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("showSubDistricts")]
        public CBool ShowSubDistricts
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("panSpeed")]
        public CFloat PanSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("iconScale")]
        public CFloat IconScale
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("zoom")]
        public CFloat Zoom
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("mappinFilterGroups")]
        public CArray<TweakDBID> MappinFilterGroups
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
