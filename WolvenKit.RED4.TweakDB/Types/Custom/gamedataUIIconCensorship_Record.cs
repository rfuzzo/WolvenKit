namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataUIIconCensorship_Record : gamedataTweakDBRecord
    {
        [RED("replacer")]
        public TweakDBID Replacer
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("censorFlags")]
        public CArray<TweakDBID> CensorFlags
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("censoredIcon")]
        public TweakDBID CensoredIcon
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
