namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMappinUIRuntimeProfile_Record : gamedataTweakDBRecord
    {
        [RED("clampX")]
        public CBool ClampX
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("showTrackedIcon")]
        public CBool ShowTrackedIcon
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("useQuestProperties")]
        public CBool UseQuestProperties
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("opacityDistanceParams")]
        public TweakDBID OpacityDistanceParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("hoverRadius")]
        public CFloat HoverRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("worldOffset")]
        public Vector3 WorldOffset
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("scaleDistanceScanningParams")]
        public TweakDBID ScaleDistanceScanningParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("visibleInTier")]
        public CArray<CBool> VisibleInTier
        {
            get => GetProperty<CArray<CBool>>();
            set => SetProperty<CArray<CBool>>(value);
        }
        
        [RED("clampY")]
        public CBool ClampY
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("showDistanceMinRange")]
        public CFloat ShowDistanceMinRange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("clampingParams")]
        public TweakDBID ClampingParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("showDistance")]
        public CBool ShowDistance
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("clampRectMargin")]
        public Vector2 ClampRectMargin
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("scaleDistanceParams")]
        public TweakDBID ScaleDistanceParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("keepNameplate")]
        public CBool KeepNameplate
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("visibleInBraindance")]
        public CBool VisibleInBraindance
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("screenOffset")]
        public Vector2 ScreenOffset
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("showNameMinRange")]
        public CFloat ShowNameMinRange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("priority")]
        public CInt32 Priority
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("visibleInScanning")]
        public CBool VisibleInScanning
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("scaleByDistance")]
        public CBool ScaleByDistance
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("opacityCustomParams")]
        public TweakDBID OpacityCustomParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("opacityAngleParams")]
        public TweakDBID OpacityAngleParams
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("clampEllipseSize")]
        public Vector2 ClampEllipseSize
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("dynamicClamping")]
        public CBool DynamicClamping
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
