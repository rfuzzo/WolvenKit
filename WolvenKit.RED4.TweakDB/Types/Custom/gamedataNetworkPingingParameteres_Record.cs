namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataNetworkPingingParameteres_Record : gamedataTweakDBRecord
    {
        [RED("networkRevealDuration")]
        public CFloat NetworkRevealDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("pulseRange")]
        public CFloat PulseRange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("pingRange")]
        public CFloat PingRange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("shouldNetworkElementsPersistAfterFocus")]
        public CBool ShouldNetworkElementsPersistAfterFocus
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("suppressPingIfBackdoorsFound")]
        public CBool SuppressPingIfBackdoorsFound
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("ammountOfIntervals")]
        public CInt32 AmmountOfIntervals
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("forceInstantBeamKill")]
        public CBool ForceInstantBeamKill
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("spacePingDuration")]
        public CFloat SpacePingDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("revealLinksAfterLeavingFocusDuration")]
        public CFloat RevealLinksAfterLeavingFocusDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("revealMaster")]
        public CBool RevealMaster
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("maxFreePingLinks")]
        public CInt32 MaxFreePingLinks
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("quickHacksExposedByDefaul")]
        public CBool QuickHacksExposedByDefaul
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("usePulse")]
        public CBool UsePulse
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("spacePingAppearModifier")]
        public CFloat SpacePingAppearModifier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("directPingDuration")]
        public CFloat DirectPingDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("allowSimultanousPinging")]
        public CBool AllowSimultanousPinging
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("revealSlave")]
        public CBool RevealSlave
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("virtualNetwork")]
        public TweakDBID VirtualNetwork
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("revealMasterAfterLeavingFocusDuration")]
        public CFloat RevealMasterAfterLeavingFocusDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("reavealNetworkOnMaster")]
        public CBool ReavealNetworkOnMaster
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("shouldRevealNetworkAfterPulse")]
        public CBool ShouldRevealNetworkAfterPulse
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("pulseRealObjects")]
        public CBool PulseRealObjects
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("showOnlyTargetQuickHacks")]
        public CBool ShowOnlyTargetQuickHacks
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
