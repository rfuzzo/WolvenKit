namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMappinUISpawnProfile_Record : gamedataTweakDBRecord
    {
        [RED("despawnDistance")]
        public CFloat DespawnDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spawnDistance")]
        public CFloat SpawnDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
