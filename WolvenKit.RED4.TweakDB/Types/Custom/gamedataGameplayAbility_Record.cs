namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataGameplayAbility_Record : gamedataTweakDBRecord
    {
        [RED("showInCodex")]
        public CBool ShowInCodex
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("prereqsForUse")]
        public CArray<TweakDBID> PrereqsForUse
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("loc_key_name")]
        public gamedataLocKeyWrapper Loc_key_name
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("abilityPackage")]
        public TweakDBID AbilityPackage
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("loc_key_desc")]
        public gamedataLocKeyWrapper Loc_key_desc
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
    }
}
