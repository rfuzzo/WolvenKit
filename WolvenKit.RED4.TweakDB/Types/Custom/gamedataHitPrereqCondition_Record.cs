namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataHitPrereqCondition_Record : gamedataTweakDBRecord
    {
        [RED("object")]
        public CName Object
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("distanceRequired")]
        public CFloat DistanceRequired
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("isMoving")]
        public CBool IsMoving
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("bodyPart")]
        public CName BodyPart
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("comparisonSource")]
        public CName ComparisonSource
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("source")]
        public CName Source
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("rarity")]
        public CString Rarity
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("valueToCheck")]
        public CFloat ValueToCheck
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("npcType")]
        public CString NpcType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("dotType")]
        public CString DotType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("attackSubtype")]
        public CString AttackSubtype
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("targetType")]
        public CName TargetType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("attackType")]
        public CString AttackType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("hitFlag")]
        public CString HitFlag
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("comparisonType")]
        public CString ComparisonType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("comparisonTarget")]
        public CName ComparisonTarget
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("tagToCheck")]
        public CName TagToCheck
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("statusEffect")]
        public CName StatusEffect
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("objectToCheck")]
        public CName ObjectToCheck
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("instigatorType")]
        public CName InstigatorType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("statPoolToCompare")]
        public CString StatPoolToCompare
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("ammoState")]
        public CString AmmoState
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("weaponType")]
        public CName WeaponType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("checkType")]
        public CName CheckType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("type")]
        public TweakDBID Type
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
