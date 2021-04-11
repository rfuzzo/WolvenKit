namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataProgram_Record : gamedataTweakDBRecord
    {
        [RED("program")]
        public TweakDBID Program
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("charactersChain")]
        public CArray<CInt32> CharactersChain
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("programName")]
        public gamedataLocKeyWrapper ProgramName
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
    }
}
