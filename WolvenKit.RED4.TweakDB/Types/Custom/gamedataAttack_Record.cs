namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAttack_Record : gamedataTweakDBRecord
    {
        [RED("playerIncomingDamageMultiplier")]
        public CFloat PlayerIncomingDamageMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("hitFlags")]
        public CArray<CString> HitFlags
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("attackType")]
        public TweakDBID AttackType
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
        
        [RED("statusEffects")]
        public CArray<TweakDBID> StatusEffects
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("userDataPath")]
        public CString UserDataPath
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("className")]
        public CName ClassName
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
        
        [RED("statModifiers")]
        public CArray<TweakDBID> StatModifiers
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("damageType")]
        public TweakDBID DamageType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("useDefaultAimData")]
        public CBool UseDefaultAimData
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("attackName")]
        public CString AttackName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("range")]
        public CFloat Range
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
