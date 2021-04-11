namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAINPCTypeCond_Record : gamedataTweakDBRecord
    {
        [RED("isFollower")]
        public CInt32 IsFollower
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("allowedNPCTypes")]
        public CArray<TweakDBID> AllowedNPCTypes
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
