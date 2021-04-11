namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataSeatState_Record : gamedataTweakDBRecord
    {
        [RED("forceOpen")]
        public CBool ForceOpen
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("forceLock")]
        public CBool ForceLock
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("forceUnlock")]
        public CBool ForceUnlock
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("disableInteraction")]
        public CBool DisableInteraction
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("forceClose")]
        public CBool ForceClose
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("questLock")]
        public CBool QuestLock
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("enableInteraction")]
        public CBool EnableInteraction
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
