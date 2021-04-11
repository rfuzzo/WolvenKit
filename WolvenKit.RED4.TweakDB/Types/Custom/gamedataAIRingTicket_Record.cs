namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIRingTicket_Record : gamedataTweakDBRecord
    {
        [RED("startCooldownOnFailure")]
        public CBool StartCooldownOnFailure
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("maxTicketDesyncTime")]
        public CFloat MaxTicketDesyncTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("ringType")]
        public TweakDBID RingType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("syncTimeout")]
        public CFloat SyncTimeout
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
        
        [RED("deactivationCondition")]
        public CArray<TweakDBID> DeactivationCondition
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
        
        [RED("conditionSuccessDuration")]
        public CFloat ConditionSuccessDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("timeout")]
        public CFloat Timeout
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxNumberOfTickets")]
        public CInt32 MaxNumberOfTickets
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
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
        
        [RED("deactivationConditionCheckInterval")]
        public CFloat DeactivationConditionCheckInterval
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("syncWithTickets")]
        public CArray<TweakDBID> SyncWithTickets
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("scaleNumberOfTicketsFromWorkspots")]
        public CBool ScaleNumberOfTicketsFromWorkspots
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("minNumberOfTickets")]
        public CInt32 MinNumberOfTickets
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("cooldowns")]
        public CArray<TweakDBID> Cooldowns
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("releaseAll")]
        public CBool ReleaseAll
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("percentageNumberOfTickets")]
        public CFloat PercentageNumberOfTickets
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
