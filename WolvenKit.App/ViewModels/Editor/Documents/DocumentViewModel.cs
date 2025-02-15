using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using HandyControl.Controls;
using Orc.ProjectManagement;
using WolvenKit.Common;
using WolvenKit.Common.Model;
using WolvenKit.Common.Model.Cr2w;
using WolvenKit.Common.Services;
using WolvenKit.CR2W.SRT;
using WolvenKit.Functionality.Commands;
using WolvenKit.Models;
using WolvenKit.MVVM.Model.ProjectManagement.Project;
using WolvenKit.ViewModels.Shell;

namespace WolvenKit.ViewModels.Editor
{
    public class DocumentViewModel : PaneViewModel, IDocumentViewModel
    {
        #region fields

        private static ImageSourceConverter ISC = new ImageSourceConverter();
        private ICommand _closeCommand = null;
        private string _filePath = null;
        private string _initialPath;
        
        private bool _IsExistingInFileSystem;
        private bool _isInitialized;
        private ICommand _saveAsCommand = null;
        private ICommand _saveCommand = null;
        private ChunkViewModel _selectedChunk;
        private string _textContent = string.Empty;
        private IWorkSpaceViewModel _workSpaceViewModel = null;
        private FileSystemInfoModel fileinfo;

        #endregion fields

        #region ctors

        public DocumentViewModel(IWorkSpaceViewModel workSpaceViewModel,
                                FileSystemInfoModel model,
                                bool isExistingInFileSystem)
            : this(workSpaceViewModel)
        {
            fileinfo = model;
            _initialPath = fileinfo.FullName;

            try
            {
                Title = System.IO.Path.GetFileName(fileinfo.FullName);
            }
            catch { }

            ContentId = fileinfo.FullName;
            _IsExistingInFileSystem = isExistingInFileSystem;
        }

        public DocumentViewModel(IWorkSpaceViewModel workSpaceViewModel)
            : this()
        {
            _workSpaceViewModel = workSpaceViewModel;
        }

        public DocumentViewModel()
        {
            IsDirty = false;

            OpenEditorCommand = new RelayCommand(ExecuteOpenEditor, CanOpenEditor);
            OpenBufferCommand = new RelayCommand(ExecuteOpenBuffer, CanOpenBuffer);
            OpenImportCommand = new RelayCommand(ExecuteOpenImport, CanOpenImport);


        }

        #endregion ctors

        #region commands

        public ICommand OpenBufferCommand { get; private set; }
        public ICommand OpenEditorCommand { get; private set; }
        public ICommand OpenImportCommand { get; private set; }

        /// <summary>Gets a command to save this document's content into another file in the file system.</summary>
        public ICommand SaveAsCommand
        {
            get
            {
                if (_saveAsCommand == null)
                {
                    _saveAsCommand = new DelegateCommand<object>((p) => OnSaveAs(p), (p) => CanSaveAs(p));
                }

                return _saveAsCommand;
            }
        }

        /// <summary>Gets a command to save this document's content into the file system.</summary>
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new DelegateCommand<object>((p) => OnSave(p), (p) => CanSave(p));
                }

                return _saveCommand;
            }
        }

        private bool CanOpenBuffer() => true;

        private bool CanOpenEditor() => true;

        private bool CanOpenImport() => true;

        private void ExecuteOpenBuffer()
        {
            // TODO: Handle command logic here
        }

        private void ExecuteOpenEditor()
        {
            // TODO: Handle command logic here
        }

        private void ExecuteOpenImport()
        {
            // TODO: Handle command logic here
        }

        #endregion commands

        #region Properties

        /// <summary>
        /// Gets or sets the editable File.
        /// </summary>
        [Model]
        public IWolvenkitFile File
        {
            get => GetValue<IWolvenkitFile>(FileProperty);
            private set => SetValue(FileProperty, value);
        }

        /// <summary>
        /// Register the dependency property so it is known in the class.
        /// </summary>
        public static readonly PropertyData FileProperty = RegisterProperty(nameof(File), typeof(IWolvenkitFile));

        //private IWolvenkitFile File { get; set; }

        /// <summary>
        /// Bound to the View
        /// </summary>
        public List<ICR2WBuffer> Buffers => File.Buffers;

        /// <summary>
        /// Bound to the View
        /// </summary>
        public List<ChunkViewModel> Chunks => File.Chunks
            .Where(_ => _.VirtualParentChunk == null)
            .Select(_ => new ChunkViewModel(_)).ToList();

        /// <summary>Gets a command to close this document.</summary>
        public ICommand CloseCommand =>
            _closeCommand ??= new DelegateCommand<object>((p) => OnClose(), (p) => CanClose());

        /// <summary>
        /// Bound to the View
        /// </summary>
        public List<EditorViewModel> Editors => GetEditorsForFile(File);

        /// <summary>Gets the current filename of the file being managed in this document viewmodel.</summary>
        public string FileName
        {
            get
            {
                if (FilePath == null)
                {
                    return "Noname" + (IsDirty ? "*" : "");
                }

                return Path.GetFileName(FilePath) + (IsDirty ? "*" : "");
            }
        }

        /// <summary>
        /// Gets the current path of the file being managed in this document viewmodel.
        /// </summary>
        public string FilePath
        {
            get => _filePath;
            set
            {
                if (_filePath != value)
                {
                    var oldValue = _filePath;
                    _filePath = value;
                    RaisePropertyChanged(nameof(FilePath));
                    RaisePropertyChanged(nameof(FileName));
                    RaisePropertyChanged(nameof(Title));
                }
            }
        }

        /// <summary>
        /// Bound to the View
        /// </summary>
        public List<ICR2WImport> Imports => File.Imports;

        public void SetIsDirty(bool b) => IsDirty = b;

        /// <summary>
        /// Gets/sets whether the documents content has been changed without saving into file system or not.
        /// </summary>
        public bool IsExistingInFileSystem
        {
            get => _IsExistingInFileSystem;
            set
            {
                if (_IsExistingInFileSystem != value)
                {
                    _IsExistingInFileSystem = value;
                    RaisePropertyChanged(nameof(IsExistingInFileSystem));
                }
            }
        }

        /// <summary>
        /// Bound to the View via TreeViewBehavior.cs
        /// </summary>
        public ChunkViewModel SelectedChunk
        {
            get => _selectedChunk;
            set
            {
                if (_selectedChunk != value)
                {
                    var oldValue = _selectedChunk;
                    _selectedChunk = value;
                    RaisePropertyChanged(() => SelectedChunk, oldValue, value);

                    //SelectEditableVariables = _selectedChunk?.ChildrenProperties;
                }
            }
        }

        

        private List<EditorViewModel> GetEditorsForFile(IWolvenkitFile file) => new();

        #endregion Properties

        #region methods

        /// <summary>
        /// Attempts to read the contents of a text file and assigns it to
        /// text content of this viewmodel.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>True if file read was successful, otherwise false</returns>
        public async Task<bool> OpenFileAsync(string path)
        {
            _isInitialized = false;

            try
            {
                // This is the same default buffer size as
                // <see cref="StreamReader"/> and <see cref="FileStream"/>.
                // int DefaultBufferSize = 4096;

                // Indicates that
                // 1. The file is to be used for asynchronous reading.
                // 2. The file is to be accessed sequentially from beginning to end.
                // FileOptions DefaultOptions = FileOptions.Asynchronous | FileOptions.SequentialScan;

                var logger = ServiceLocator.Default.ResolveType<ILoggerService>();
                logger.LogString("Opening file: " + path + "...");

                //TODO
                await using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    EFileReadErrorCodes errorcode;
                    using var reader = new BinaryReader(stream);

                    if (Path.GetExtension(path) == ".srt")
                    {
                        File = new Srtfile()
                        {
                            FileName = path
                        };
                        errorcode = await File.Read(reader);
                    }
                    else
                    {
                        // check game
                        var pm = ServiceLocator.Default.ResolveType<IProjectManager>();
                        //var fileService = ServiceLocator.Default.ResolveType<IWolvenkitFileService>();
                        switch (pm.ActiveProject)
                        {
                            case Cp77Project cp77proj:
                                var cr2w = CP77.CR2W.ModTools.TryReadCr2WFile(reader);
                                if (cr2w == null)
                                {
                                    logger.LogString($"Failed to read cr2w file {path}", Logtype.Error);
                                    return false;
                                }
                                cr2w.FileName = path;

                                File = cr2w;

                                // events
                                

                                break;

                            case Tw3Project tw3proj:
                                throw new NotImplementedException();

                            default:
                                _isInitialized = false;
                                return false;
                        }
                    }
                }

                ContentId = path;
                FilePath = path;
                IsDirty = false;
                Title = FileName;
                _isInitialized = true;

                return true;
            }
            catch (Exception)
            {
                // Not processing this catch in any other way than rejecting to initialize this
                _isInitialized = false;
            }

            return false;
        }

        /// <summary>
        /// Attempts to read the contents of a text file fined via initialPath
        /// and assigns it to text content of this viewmodel.
        /// </summary>
        /// <returns>True if file read was successful, otherwise false</returns>
        public async Task<bool> OpenFileWithInitialPathAsync()
        {
            if (string.IsNullOrEmpty(_initialPath) && _isInitialized == false)
            {
                return false;
            }

            if (_isInitialized || _IsExistingInFileSystem == false)
            {
                return true;
            }

            var result = await OpenFileAsync(_initialPath);

            if (result == true)
            {
                _initialPath = null;
            }

            return result;
        }

        private bool CanClose() => true;

        private bool CanSave(object parameter) => IsDirty;

        private bool CanSaveAs(object parameter) => IsDirty;

        private void OnClose() => _workSpaceViewModel.Close(this);

        private void OnSave(object parameter)
        {
            using var fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite);
            using var bw = new BinaryWriter(fs);
            File.Write(bw);
        }

        private void OnSaveAs(object parameter)
        {
            throw new NotImplementedException();
        }

        #endregion methods

        
    }

    public class EditorViewModel
    {
        #region Constructors

        public EditorViewModel()
        {
        }

        #endregion Constructors

        #region Properties

        public string Name { get; } = "TBA";

        #endregion Properties
    }
}
