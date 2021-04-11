namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataGameplayAbilityGroup_Record : gamedataTweakDBRecord
    {
        [RED("abilities")]
        public CArray<TweakDBID> Abilities
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
