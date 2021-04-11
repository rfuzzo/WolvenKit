namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIStateCond_Record : gamedataTweakDBRecord
    {
        [RED("inStates")]
        public CArray<CName> InStates
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("checkAllTypes")]
        public CBool CheckAllTypes
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
