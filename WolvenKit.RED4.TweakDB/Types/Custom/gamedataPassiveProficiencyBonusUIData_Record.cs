namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPassiveProficiencyBonusUIData_Record : gamedataTweakDBRecord
    {
        [RED("floatValues")]
        public CArray<CFloat> FloatValues
        {
            get => GetProperty<CArray<CFloat>>();
            set => SetProperty<CArray<CFloat>>(value);
        }
        
        [RED("stats")]
        public CArray<TweakDBID> Stats
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("loc_desc_key")]
        public gamedataLocKeyWrapper Loc_desc_key
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("loc_name_key")]
        public gamedataLocKeyWrapper Loc_name_key
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("intValues")]
        public CArray<CInt32> IntValues
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
    }
}
