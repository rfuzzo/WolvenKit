namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIDirectorScheduleSpawningDesc_Record : gamedataTweakDBRecord
    {
        [RED("enemiesAmount")]
        public CInt32 EnemiesAmount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("spawningAngle")]
        public CFloat SpawningAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spawningMinDistance")]
        public CFloat SpawningMinDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spawningBigDistance")]
        public CFloat SpawningBigDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("entries")]
        public CArray<TweakDBID> Entries
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
