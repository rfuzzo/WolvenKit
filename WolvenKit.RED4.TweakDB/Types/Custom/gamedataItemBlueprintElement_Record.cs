namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataItemBlueprintElement_Record : gamedataTweakDBRecord
    {
        [RED("prereqID")]
        public TweakDBID PrereqID
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("childElements")]
        public CArray<TweakDBID> ChildElements
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("slot")]
        public TweakDBID Slot
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
