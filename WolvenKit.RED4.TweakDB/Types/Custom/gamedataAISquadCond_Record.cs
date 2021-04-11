namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISquadCond_Record : gamedataTweakDBRecord
    {
        [RED("hasTickets")]
        public CArray<TweakDBID> HasTickets
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("ticketsConditionCheck")]
        public CArray<TweakDBID> TicketsConditionCheck
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
