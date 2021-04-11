namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataHUD_Preset_Entry_Record : gamedataTweakDBRecord
    {
        [RED("hudEntries")]
        public CArray<CName> HudEntries
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
    }
}
