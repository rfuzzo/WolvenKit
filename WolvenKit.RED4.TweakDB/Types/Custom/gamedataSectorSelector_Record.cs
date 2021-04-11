namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataSectorSelector_Record : gamedataTweakDBRecord
    {
        [RED("homeBackMid")]
        public CBool HomeBackMid
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("targetMid")]
        public CBool TargetMid
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("homeRight")]
        public CBool HomeRight
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("homeLeft")]
        public CBool HomeLeft
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("targetBackMid")]
        public CBool TargetBackMid
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("targetBackLeft")]
        public CBool TargetBackLeft
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("homeMid")]
        public CBool HomeMid
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("defensiveSelection")]
        public CBool DefensiveSelection
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("homeBackLeft")]
        public CBool HomeBackLeft
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("targetLeft")]
        public CBool TargetLeft
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("targetRight")]
        public CBool TargetRight
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("homeBackRight")]
        public CBool HomeBackRight
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("targetBackRight")]
        public CBool TargetBackRight
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
