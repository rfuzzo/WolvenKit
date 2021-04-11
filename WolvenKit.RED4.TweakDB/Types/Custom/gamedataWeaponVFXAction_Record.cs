namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataWeaponVFXAction_Record : gamedataTweakDBRecord
    {
        [RED("fxName")]
        public CName FxName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("fxActionType")]
        public TweakDBID FxActionType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("fxAction")]
        public TweakDBID FxAction
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
