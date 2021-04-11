namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIActionTicket_Record : gamedataTweakDBRecord
    {
        [RED("conditionSuccessDuration")]
        public CFloat ConditionSuccessDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("percentageNumberOfTickets")]
        public CFloat PercentageNumberOfTickets
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("cooldowns")]
        public CArray<TweakDBID> Cooldowns
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("ticketType")]
        public TweakDBID TicketType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("syncWithTickets")]
        public CArray<TweakDBID> SyncWithTickets
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("deactivationCondition")]
        public CArray<TweakDBID> DeactivationCondition
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("maxTicketDesyncTime")]
        public CFloat MaxTicketDesyncTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("syncTimeout")]
        public CFloat SyncTimeout
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("deactivationConditionCheckInterval")]
        public CFloat DeactivationConditionCheckInterval
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("releaseAll")]
        public CBool ReleaseAll
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("startCooldownOnFailure")]
        public CBool StartCooldownOnFailure
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("maxNumberOfTickets")]
        public CInt32 MaxNumberOfTickets
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("scaleNumberOfTicketsFromWorkspots")]
        public CBool ScaleNumberOfTicketsFromWorkspots
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("activationCondition")]
        public CArray<TweakDBID> ActivationCondition
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("minTicketDesyncTime")]
        public CFloat MinTicketDesyncTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("revokeOnTimeout")]
        public CBool RevokeOnTimeout
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("timeout")]
        public CFloat Timeout
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minNumberOfTickets")]
        public CInt32 MinNumberOfTickets
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
