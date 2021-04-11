namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAttack_Landing_Record : gamedataTweakDBRecord
    {
        [RED("attackType")]
        public TweakDBID AttackType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("damageType")]
        public TweakDBID DamageType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("hitReactionSeverityMin")]
        public CInt32 HitReactionSeverityMin
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("fxPackage")]
        public TweakDBID FxPackage
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("effectName")]
        public CName EffectName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("hitReactionSeverityMax")]
        public CInt32 HitReactionSeverityMax
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("hitFlags")]
        public CArray<CString> HitFlags
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("statModifiers")]
        public CArray<TweakDBID> StatModifiers
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("statusEffects")]
        public CArray<TweakDBID> StatusEffects
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("range")]
        public CFloat Range
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("useDefaultAimData")]
        public CBool UseDefaultAimData
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("className")]
        public CName ClassName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("attackTag")]
        public CName AttackTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("effectTag")]
        public CName EffectTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("attackName")]
        public CString AttackName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("playerIncomingDamageMultiplier")]
        public CFloat PlayerIncomingDamageMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("audioAttackIndex")]
        public CFloat AudioAttackIndex
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("userDataPath")]
        public CString UserDataPath
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("audioTag")]
        public CName AudioTag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
