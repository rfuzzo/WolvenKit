namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleDefaultState_Record : gamedataTweakDBRecord
    {
        [RED("trunk")]
        public TweakDBID Trunk
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("hood")]
        public TweakDBID Hood
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("seat_front_right")]
        public TweakDBID Seat_front_right
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("SirenLight")]
        public CBool SirenLight
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("DisableAllInteractions")]
        public CBool DisableAllInteractions
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("CloseAll")]
        public CBool CloseAll
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("QuestLockAll")]
        public CBool QuestLockAll
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("Thrusters")]
        public CBool Thrusters
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("SirenSounds")]
        public CBool SirenSounds
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("LockAll")]
        public CBool LockAll
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("seat_front_left")]
        public TweakDBID Seat_front_left
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("seat_back_left")]
        public TweakDBID Seat_back_left
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("OpenAll")]
        public CBool OpenAll
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("seat_back_right")]
        public TweakDBID Seat_back_right
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
