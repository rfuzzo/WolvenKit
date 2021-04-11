namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataHackingMiniGame_Record : gamedataTweakDBRecord
    {
        [RED("initialTimer")]
        public CInt32 InitialTimer
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("predefinedGrid")]
        public CArray<CString> PredefinedGrid
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("symbols")]
        public CArray<CString> Symbols
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("allowedTraps")]
        public CArray<TweakDBID> AllowedTraps
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("hiddenCellsProbability")]
        public CInt32 HiddenCellsProbability
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("symbolProbabilities")]
        public CArray<CString> SymbolProbabilities
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("officer")]
        public CBool Officer
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("predefinedNetworkPrograms")]
        public CArray<CString> PredefinedNetworkPrograms
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("hasInitialTimer")]
        public CBool HasInitialTimer
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("dimension")]
        public CInt32 Dimension
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("hasHiddenCells")]
        public CBool HasHiddenCells
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("enemyNetrunnerLevel")]
        public CInt32 EnemyNetrunnerLevel
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("symbolProbabilitiesAlternative")]
        public CArray<CString> SymbolProbabilitiesAlternative
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("predefinedBasicAccess")]
        public CArray<CString> PredefinedBasicAccess
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("bufferModifier")]
        public CInt32 BufferModifier
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("hasEnemyNetrunner")]
        public CBool HasEnemyNetrunner
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("networkLevel")]
        public CInt32 NetworkLevel
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("predefinedEnemyPrograms")]
        public CArray<CString> PredefinedEnemyPrograms
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("predefinedCyberdeckPrograms")]
        public CArray<CString> PredefinedCyberdeckPrograms
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("gameType")]
        public CInt32 GameType
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
