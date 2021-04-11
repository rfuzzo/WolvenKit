namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMinigame_Def_Record : gamedataTweakDBRecord
    {
        [RED("forbiddenPrograms")]
        public CArray<TweakDBID> ForbiddenPrograms
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("overrideProgramsList")]
        public CArray<TweakDBID> OverrideProgramsList
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("forbiddenProgramsList")]
        public CArray<TweakDBID> ForbiddenProgramsList
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("defaultTrap")]
        public TweakDBID DefaultTrap
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("saveSeed")]
        public CBool SaveSeed
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("failExitText")]
        public CName FailExitText
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("canceledExitText")]
        public CName CanceledExitText
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("bufferFullExitText")]
        public CName BufferFullExitText
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("noTraps")]
        public CBool NoTraps
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("bufferSize")]
        public CInt32 BufferSize
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("useProgression")]
        public CBool UseProgression
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("timeOutExitText")]
        public CName TimeOutExitText
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("greatSuccessExitText")]
        public CName GreatSuccessExitText
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("gridSymbols")]
        public CArray<TweakDBID> GridSymbols
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("overlapProbability")]
        public CFloat OverlapProbability
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("genericExitText")]
        public CName GenericExitText
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("gridTraps")]
        public CArray<TweakDBID> GridTraps
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("successExitText")]
        public CName SuccessExitText
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("trapsProbability")]
        public CFloat TrapsProbability
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("additionalProgramsList")]
        public CArray<TweakDBID> AdditionalProgramsList
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("gridSize")]
        public CInt32 GridSize
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("timeLimit")]
        public CFloat TimeLimit
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
