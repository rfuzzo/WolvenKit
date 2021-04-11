namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataBase_MappinDefinition_Record : gamedataTweakDBRecord
    {
        [RED("showOnMinimap")]
        public CBool ShowOnMinimap
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("showOnMap")]
        public CBool ShowOnMap
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("showInWorld")]
        public CBool ShowInWorld
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("visibilityRange")]
        public CFloat VisibilityRange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
