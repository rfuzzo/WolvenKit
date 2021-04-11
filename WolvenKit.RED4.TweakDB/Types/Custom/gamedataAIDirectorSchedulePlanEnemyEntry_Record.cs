namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIDirectorSchedulePlanEnemyEntry_Record : gamedataTweakDBRecord
    {
        [RED("spawnChanceFactor")]
        public CFloat SpawnChanceFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("character")]
        public TweakDBID Character
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("tags")]
        public CArray<CName> Tags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("maxAmountConcurrently")]
        public CInt32 MaxAmountConcurrently
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
