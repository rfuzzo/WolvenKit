namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMaterialFx_Record : gamedataTweakDBRecord
    {
        [RED("impact_decal")]
        public CArray<raRef<CResource>> Impact_decal
        {
            get => GetProperty<CArray<raRef<CResource>>>();
            set => SetProperty<CArray<raRef<CResource>>>(value);
        }
        
        [RED("impact_reflected_effect")]
        public CArray<raRef<CResource>> Impact_reflected_effect
        {
            get => GetProperty<CArray<raRef<CResource>>>();
            set => SetProperty<CArray<raRef<CResource>>>(value);
        }
        
        [RED("impact_dismemberment_piercing")]
        public CArray<raRef<CResource>> Impact_dismemberment_piercing
        {
            get => GetProperty<CArray<raRef<CResource>>>();
            set => SetProperty<CArray<raRef<CResource>>>(value);
        }
        
        [RED("impact_pierce_splatter_far")]
        public CArray<raRef<CResource>> Impact_pierce_splatter_far
        {
            get => GetProperty<CArray<raRef<CResource>>>();
            set => SetProperty<CArray<raRef<CResource>>>(value);
        }
        
        [RED("pierce_near_distance")]
        public CFloat Pierce_near_distance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("pierce_far_distance")]
        public CFloat Pierce_far_distance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("reflected_angle_max")]
        public CFloat Reflected_angle_max
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("impact_main_effect")]
        public CArray<raRef<CResource>> Impact_main_effect
        {
            get => GetProperty<CArray<raRef<CResource>>>();
            set => SetProperty<CArray<raRef<CResource>>>(value);
        }
        
        [RED("impact_pierce_decal")]
        public CArray<raRef<CResource>> Impact_pierce_decal
        {
            get => GetProperty<CArray<raRef<CResource>>>();
            set => SetProperty<CArray<raRef<CResource>>>(value);
        }
        
        [RED("impact_pierce_splatter_near")]
        public CArray<raRef<CResource>> Impact_pierce_splatter_near
        {
            get => GetProperty<CArray<raRef<CResource>>>();
            set => SetProperty<CArray<raRef<CResource>>>(value);
        }
        
        [RED("pierce_enter")]
        public CBool Pierce_enter
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("pierce_exit")]
        public CBool Pierce_exit
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("impact_pierce_effect")]
        public CArray<raRef<CResource>> Impact_pierce_effect
        {
            get => GetProperty<CArray<raRef<CResource>>>();
            set => SetProperty<CArray<raRef<CResource>>>(value);
        }
    }
}
