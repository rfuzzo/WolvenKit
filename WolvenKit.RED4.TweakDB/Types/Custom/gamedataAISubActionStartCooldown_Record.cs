namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionStartCooldown_Record : gamedataTweakDBRecord
    {
        [RED("cooldowns")]
        public CArray<TweakDBID> Cooldowns
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
