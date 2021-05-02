using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using Splat;
using WolvenKit.Functionality.Services;
using WolvenKit.Common;
using WolvenKit.Common.Model;
using WolvenKit.Functionality.Controllers;
using WolvenKit.Models.Wizards;
using WolvenKit.MVVM.Model.ProjectManagement.Project;
using WolvenKit.ViewModels.Others;
using ViewModelBase = WolvenKit.App.ViewModels.ViewModelBase;

namespace WolvenKit.ViewModels.Wizards.PublishWizard
{
    public class FinalizeSetupViewModel : ViewModelBase
    {
        #region fields
        private readonly IProjectManager projectManager;
        #endregion fields

        #region constructors

        public FinalizeSetupViewModel()
        {
            projectManager = Locator.Current.GetService<IProjectManager>();
            if (projectManager.ActiveProject is EditorProject ep)
            {
                EditorProjectData = ep.Data;
            }

            PublishProject = ReactiveCommand.CreateFromTask(PublishProjectExecuteAsync);
            Cancel = ReactiveCommand.CreateFromTask(CancelExecuteAsync);
        }

        #endregion constructors

        #region properties

        /// <summary>
        /// Gets or sets the EditorProjectData.
        /// </summary>
        public EditorProjectData EditorProjectData { get; set; }

        /// <summary>
        /// Gets or sets the PublishWizardModel.
        /// </summary>
        public PublishWizardModel PublishWizardModel { get; set; }

        #endregion properties

        #region commands

        public ReactiveCommand<Unit, Unit> PublishProject { get; }

        public ReactiveCommand<Unit, Unit> Cancel { get; }

        private async Task PublishProjectExecuteAsync()
        {
            //var dofc = new DetermineOpenFileContext()
            //{
            //    Filter = "WolvenKit Package | *.wkp | Zip file | *.zip",
            //    IsMultiSelect = false,
            //    Title = "Please select where to save the WolvenKit package."
            //};
            //var result = await _openFileService.DetermineFileAsync(dofc);
            //if (result.Result)
            //{
            //    //result.DirectoryName;
            //    await MainController.GetGame().PackAndInstallProject();
            //    await MainController.GetGame().PackageMod();
            //    var host = ServiceLocator.Default.ResolveType<UserControlHostWindowViewModel>();
            //    host?.CloseViewModelAsync(true);
            //}
        }

        private Task CancelExecuteAsync()
        {
            //var host = ServiceLocator.Default.ResolveType<UserControlHostWindowViewModel>();
            //host?.CloseViewModelAsync(true);
            return Task.CompletedTask;
        }

        #endregion commands
    }
}
