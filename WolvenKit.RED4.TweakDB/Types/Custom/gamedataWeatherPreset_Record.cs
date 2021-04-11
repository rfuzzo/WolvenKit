namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataWeatherPreset_Record : gamedataSpawnableObject_Record
    {
        [RED("name")]
        public CName Name
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
