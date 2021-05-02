using WolvenKit.App.ViewModels;
using WolvenKit.Models.Wizards;

namespace WolvenKit.ViewModels.Wizards.PublishWizard
{
    public class OptionalSettingsViewModel : ViewModelBase
    {
        #region constructors

        public OptionalSettingsViewModel()
        {

        }

        #endregion constructors

        #region properties

        /// <summary>
        /// Gets or sets the PublishWizardModel.
        /// </summary>

        public PublishWizardModel PublishWizardModel { get; set; }

        #endregion properties
    }
}
