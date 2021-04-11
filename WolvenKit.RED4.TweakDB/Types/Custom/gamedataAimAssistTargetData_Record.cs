namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAimAssistTargetData_Record : gamedataTweakDBRecord
    {
        [RED("width")]
        public CFloat Width
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("aimSnapPriorityWeight")]
        public CFloat AimSnapPriorityWeight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("isForAimSnap")]
        public CBool IsForAimSnap
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("isForAimMagnetisim")]
        public CBool IsForAimMagnetisim
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("aimSnapAngle")]
        public CFloat AimSnapAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("heightUp")]
        public CFloat HeightUp
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("heightDown")]
        public CFloat HeightDown
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("filters")]
        public CArray<TweakDBID> Filters
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
