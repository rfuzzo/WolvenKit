namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataFacialPreset_Record : gamedataTweakDBRecord
    {
        [RED("lowerFaceBlendAdditive")]
        public CBool LowerFaceBlendAdditive
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("profileName")]
        public CName ProfileName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("upperFaceBlendAdditive")]
        public CBool UpperFaceBlendAdditive
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("eyesBlendAdditive")]
        public CBool EyesBlendAdditive
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
