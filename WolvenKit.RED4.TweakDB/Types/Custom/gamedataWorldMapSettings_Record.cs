namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataWorldMapSettings_Record : gamedataTweakDBRecord
    {
        [RED("mouseZoomTransitionTime")]
        public CFloat MouseZoomTransitionTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("topDownCamera")]
        public TweakDBID TopDownCamera
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("zoomLevels")]
        public CArray<TweakDBID> ZoomLevels
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("zoomTransitionTime")]
        public CFloat ZoomTransitionTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("enableGroupTransitionAnimations")]
        public CBool EnableGroupTransitionAnimations
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("cameraModeTransitionTime")]
        public CFloat CameraModeTransitionTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("freeCamera")]
        public TweakDBID FreeCamera
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("zoomToEnabledAtMinimumZoom")]
        public CFloat ZoomToEnabledAtMinimumZoom
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("zoomToZoomValue")]
        public CFloat ZoomToZoomValue
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
