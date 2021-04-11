namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAttribute_Record : gamedataTweakDBRecord
    {
        [RED("flags")]
        public CArray<CName> Flags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("enumComment")]
        public CString EnumComment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("min")]
        public CFloat Min
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("localizedStatDisplay")]
        public CString LocalizedStatDisplay
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("max")]
        public CFloat Max
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("enumName")]
        public CString EnumName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("proficiencies")]
        public CArray<TweakDBID> Proficiencies
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("localizedName")]
        public CString LocalizedName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("improvementRelation")]
        public TweakDBID ImprovementRelation
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("substats")]
        public CArray<TweakDBID> Substats
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("localizedDescription")]
        public CString LocalizedDescription
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
