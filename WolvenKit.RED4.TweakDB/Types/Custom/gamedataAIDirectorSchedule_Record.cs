namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIDirectorSchedule_Record : gamedataTweakDBRecord
    {
        [RED("entries")]
        public CArray<TweakDBID> Entries
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
