namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIActionOR_Record : gamedataTweakDBRecord
    {
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("OR")]
        public CArray<TweakDBID> OR
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
