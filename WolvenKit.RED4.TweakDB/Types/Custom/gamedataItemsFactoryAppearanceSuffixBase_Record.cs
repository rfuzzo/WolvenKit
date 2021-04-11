namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataItemsFactoryAppearanceSuffixBase_Record : gamedataTweakDBRecord
    {
        [RED("scriptedSystem")]
        public CName ScriptedSystem
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("instantSwitch")]
        public CBool InstantSwitch
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("scriptedFunction")]
        public CName ScriptedFunction
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
