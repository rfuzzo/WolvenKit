namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRPGAction_Record : gamedataTweakDBRecord
    {
        [RED("prereqs")]
        public CArray<TweakDBID> Prereqs
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("reward")]
        public TweakDBID Reward
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("actionName")]
        public CName ActionName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
