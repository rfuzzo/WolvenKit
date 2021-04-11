namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataFastTravelPoint_Record : gamedataTweakDBRecord
    {
        [RED("showInWorld")]
        public CBool ShowInWorld
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("showOnWorldMap")]
        public CBool ShowOnWorldMap
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("displayName")]
        public CString DisplayName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("description")]
        public CString Description
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("district")]
        public TweakDBID District
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
