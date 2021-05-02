using Splat;
using WolvenKit.App.ViewModels;
using WolvenKit.Functionality.Services;
using WolvenKit.Common.Model;
using WolvenKit.Models.Wizards;
using WolvenKit.MVVM.Model.ProjectManagement.Project;

namespace WolvenKit.ViewModels.Wizards.PublishWizard
{
    public class RequiredSettingsViewModel : ViewModelBase
    {
        private readonly IProjectManager projectManager;


        #region constructors

        public RequiredSettingsViewModel(
            )
        {
            projectManager = Locator.Current.GetService<IProjectManager>();

            if (projectManager.ActiveProject is EditorProject ep)
            {
                EditorProject = ep;
                EditorProjectData = ep.Data;
            }
        }

        #endregion constructors

        #region properties

        /// <summary>
        /// Gets or sets the EditorProjectData.
        /// </summary>
        public EditorProjectData EditorProjectData { get; set; }

        /// <summary>
        /// Gets or sets the EditorProject.
        /// </summary>
        public EditorProject EditorProject { get; set; }

        /// <summary>
        /// Gets or sets the PublishWizardModel.
        /// </summary>
        public PublishWizardModel PublishWizardModel { get; set; }

        #endregion properties
    }
}
