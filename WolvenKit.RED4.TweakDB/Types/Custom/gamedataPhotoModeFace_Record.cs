namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPhotoModeFace_Record : gamedataTweakDBRecord
    {
        [RED("locked")]
        public CBool Locked
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("faceId")]
        public CInt32 FaceId
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("displayName")]
        public CName DisplayName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
