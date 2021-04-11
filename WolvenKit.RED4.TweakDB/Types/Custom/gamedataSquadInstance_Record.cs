namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataSquadInstance_Record : gamedataTweakDBRecord
    {
        [RED("squadTemplate")]
        public CName SquadTemplate
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("squadName")]
        public CName SquadName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
