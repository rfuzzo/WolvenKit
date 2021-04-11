namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataContinuousAttackEffector_Record : gamedataTweakDBRecord
    {
        [RED("statModifierGroups")]
        public CArray<TweakDBID> StatModifierGroups
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("attackRecord")]
        public TweakDBID AttackRecord
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("prereqRecord")]
        public TweakDBID PrereqRecord
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("removeAfterActionCall")]
        public CBool RemoveAfterActionCall
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("delayTime")]
        public CFloat DelayTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
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
    }
}
