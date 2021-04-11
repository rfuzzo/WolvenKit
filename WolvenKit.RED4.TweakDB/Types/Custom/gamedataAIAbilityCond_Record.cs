namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIAbilityCond_Record : gamedataTweakDBRecord
    {
        [RED("abilities")]
        public CArray<TweakDBID> Abilities
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
