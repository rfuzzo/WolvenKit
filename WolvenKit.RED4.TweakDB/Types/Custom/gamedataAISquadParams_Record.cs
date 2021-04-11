namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISquadParams_Record : gamedataTweakDBRecord
    {
        [RED("prohibitedTickets")]
        public CArray<TweakDBID> ProhibitedTickets
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("allTickets")]
        public CArray<TweakDBID> AllTickets
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("overridenTickets")]
        public CArray<TweakDBID> OverridenTickets
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
