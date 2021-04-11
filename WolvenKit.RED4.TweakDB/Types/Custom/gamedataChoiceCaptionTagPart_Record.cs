namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataChoiceCaptionTagPart_Record : gamedataChoiceCaptionPart_Record
    {
        [RED("tagLocId")]
        public CString TagLocId
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
