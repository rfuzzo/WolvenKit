using WolvenKit.App.ViewModels;
using WolvenKit.Models.Wizards;

namespace WolvenKit.ViewModels.Wizards.FirstSetupWizard
{
    public class SetInitialPreferencesViewModel : ViewModelBase
    {
        #region constructors

        public SetInitialPreferencesViewModel(FirstSetupWizardModel firstSetupWizardModel)
        {
            FirstSetupWizardModel = firstSetupWizardModel;
        }

        #endregion constructors

        #region properties

        /// <summary>
        /// Gets or sets the FirstSetupWizardModel.
        /// </summary>
        public FirstSetupWizardModel FirstSetupWizardModel { get; set; }

        #endregion properties
    }
}
