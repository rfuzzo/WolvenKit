namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIAction_Record : gamedataTweakDBRecord
    {
        [RED("revokingTicketCompletesAction")]
        public CBool RevokingTicketCompletesAction
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("recovery")]
        public TweakDBID Recovery
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("initCooldowns")]
        public CArray<TweakDBID> InitCooldowns
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("startupEndConditions")]
        public CArray<TweakDBID> StartupEndConditions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("recoveryEndConditions")]
        public CArray<TweakDBID> RecoveryEndConditions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("activationCondition")]
        public TweakDBID ActivationCondition
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("animData")]
        public TweakDBID AnimData
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("cooldowns")]
        public CArray<TweakDBID> Cooldowns
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("recoverySubActions")]
        public CArray<TweakDBID> RecoverySubActions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("disableActionInMultiplayer")]
        public CBool DisableActionInMultiplayer
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("completeWithFailure")]
        public CBool CompleteWithFailure
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("loopEndConditions")]
        public CArray<TweakDBID> LoopEndConditions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("abilities")]
        public CArray<TweakDBID> Abilities
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("commands")]
        public CArray<CName> Commands
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("ticketAcknowledgeTimeout")]
        public CFloat TicketAcknowledgeTimeout
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("startup")]
        public TweakDBID Startup
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("allowBlendDuration")]
        public CFloat AllowBlendDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("lookats")]
        public CArray<TweakDBID> Lookats
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("isVirtual")]
        public CBool IsVirtual
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("waitForAnimationToLoad")]
        public CBool WaitForAnimationToLoad
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("loop")]
        public TweakDBID Loop
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("subActionsCanCompleteAction")]
        public CBool SubActionsCanCompleteAction
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("loopSubActions")]
        public CArray<TweakDBID> LoopSubActions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("ability")]
        public TweakDBID Ability
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("allowBlendPercCap")]
        public CFloat AllowBlendPercCap
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("subActions")]
        public CArray<TweakDBID> SubActions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("tickets")]
        public CArray<TweakDBID> Tickets
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("minLOD")]
        public CInt32 MinLOD
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("startupSubActions")]
        public CArray<TweakDBID> StartupSubActions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("disableAction")]
        public CBool DisableAction
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("animationWrapperOverrides")]
        public CArray<CName> AnimationWrapperOverrides
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("failIfAnimationNotStreamedIn")]
        public CBool FailIfAnimationNotStreamedIn
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
