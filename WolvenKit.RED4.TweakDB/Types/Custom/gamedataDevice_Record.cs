namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataDevice_Record : gamedataTweakDBRecord
    {
        [RED("deviceType")]
        public CString DeviceType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("statModifierGroups")]
        public CArray<TweakDBID> StatModifierGroups
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("objectActions")]
        public CArray<TweakDBID> ObjectActions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("effectors")]
        public CArray<TweakDBID> Effectors
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("audioResourceName")]
        public CName AudioResourceName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("savable")]
        public CBool Savable
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("weakspots")]
        public CArray<TweakDBID> Weakspots
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("statPools")]
        public CArray<TweakDBID> StatPools
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("statModifiers")]
        public CArray<TweakDBID> StatModifiers
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("RPGActions")]
        public CArray<TweakDBID> RPGActions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
