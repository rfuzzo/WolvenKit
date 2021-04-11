namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIVehicleCond_Record : gamedataTweakDBRecord
    {
        [RED("vehicle")]
        public TweakDBID Vehicle
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("freeSlots")]
        public CArray<TweakDBID> FreeSlots
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("driverCheck")]
        public CInt32 DriverCheck
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("hasTags")]
        public CArray<CName> HasTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("currentSpeed")]
        public Vector2 CurrentSpeed
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("activePassangers")]
        public Vector2 ActivePassangers
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
