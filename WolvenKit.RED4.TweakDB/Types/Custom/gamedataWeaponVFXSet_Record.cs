namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataWeaponVFXSet_Record : gamedataTweakDBRecord
    {
        [RED("actions")]
        public CArray<TweakDBID> Actions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
