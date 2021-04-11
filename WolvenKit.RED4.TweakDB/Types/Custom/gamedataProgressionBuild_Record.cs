namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataProgressionBuild_Record : gamedataTweakDBRecord
    {
        [RED("inventorySet")]
        public TweakDBID InventorySet
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("startingAttributes")]
        public CArray<TweakDBID> StartingAttributes
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("inventoryLayout")]
        public CArray<TweakDBID> InventoryLayout
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("perkSet")]
        public TweakDBID PerkSet
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("startingCyberware")]
        public CArray<TweakDBID> StartingCyberware
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("equipmentSet")]
        public TweakDBID EquipmentSet
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("startingPerks")]
        public CArray<TweakDBID> StartingPerks
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("cyberwareSet")]
        public TweakDBID CyberwareSet
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("enumComment")]
        public CString EnumComment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("craftBook")]
        public TweakDBID CraftBook
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("proficiencySet")]
        public TweakDBID ProficiencySet
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("randomizeClothing")]
        public CBool RandomizeClothing
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("lifePath")]
        public TweakDBID LifePath
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("startingItems")]
        public CArray<TweakDBID> StartingItems
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("attributeSet")]
        public TweakDBID AttributeSet
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("startingProficiencies")]
        public CArray<TweakDBID> StartingProficiencies
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("startingEquipment")]
        public CArray<TweakDBID> StartingEquipment
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("perkSets")]
        public CArray<TweakDBID> PerkSets
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
