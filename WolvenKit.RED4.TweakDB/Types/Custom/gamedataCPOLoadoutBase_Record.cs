namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCPOLoadoutBase_Record : gamedataTweakDBRecord
    {
        [RED("displayName")]
        public CString DisplayName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }

        [RED("items")]
        public CArray<TweakDBID> Items
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
