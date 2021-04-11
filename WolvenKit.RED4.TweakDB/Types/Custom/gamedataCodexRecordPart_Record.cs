namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCodexRecordPart_Record : gamedataTweakDBRecord
    {
        [RED("partName")]
        public CName PartName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("partContent")]
        public CString PartContent
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
