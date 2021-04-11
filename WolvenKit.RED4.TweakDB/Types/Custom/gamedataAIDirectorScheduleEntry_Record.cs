namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIDirectorScheduleEntry_Record : gamedataTweakDBRecord
    {
        [RED("entryStartType")]
        public TweakDBID EntryStartType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("duration")]
        public CFloat Duration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("killsLimit")]
        public CInt32 KillsLimit
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("plans")]
        public CArray<TweakDBID> Plans
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("tensionDelta")]
        public CFloat TensionDelta
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
