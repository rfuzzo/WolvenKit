namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPerkLevelUIData_Record : gamedataTweakDBRecord
    {
        [RED("intValues")]
        public CArray<CInt32> IntValues
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("floatValues")]
        public CArray<CFloat> FloatValues
        {
            get => GetProperty<CArray<CFloat>>();
            set => SetProperty<CArray<CFloat>>(value);
        }
        
        [RED("nameValues")]
        public CArray<CName> NameValues
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
    }
}
