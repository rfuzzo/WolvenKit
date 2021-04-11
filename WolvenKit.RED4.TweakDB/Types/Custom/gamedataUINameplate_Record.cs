namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataUINameplate_Record : gamedataTweakDBRecord
    {
        [RED("type")]
        public TweakDBID Type
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("slot")]
        public CName Slot
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("position")]
        public Vector3 Position
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("enabled")]
        public CBool Enabled
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
