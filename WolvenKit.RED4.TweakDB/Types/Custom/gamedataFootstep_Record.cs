namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataFootstep_Record : gamedataTweakDBRecord
    {
        [RED("footstepEntityLeft")]
        public CName FootstepEntityLeft
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }

        [RED("footstepEntityRight")]
        public CName FootstepEntityRight
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }

        [RED("timeToFade")]
        public CFloat TimeToFade
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
