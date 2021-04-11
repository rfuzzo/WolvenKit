namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataSpreadInitEffector_Record : gamedataTweakDBRecord
    {
        [RED("prereqRecord")]
        public TweakDBID PrereqRecord
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("bonusJumps")]
        public CInt32 BonusJumps
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("spreadCount")]
        public CInt32 SpreadCount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("statPoolUpdates")]
        public CArray<TweakDBID> StatPoolUpdates
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("effectorClassName")]
        public CName EffectorClassName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("objectAction")]
        public TweakDBID ObjectAction
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("spreadDistance")]
        public CInt32 SpreadDistance
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("statModifierGroups")]
        public CArray<TweakDBID> StatModifierGroups
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("removeAfterActionCall")]
        public CBool RemoveAfterActionCall
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
