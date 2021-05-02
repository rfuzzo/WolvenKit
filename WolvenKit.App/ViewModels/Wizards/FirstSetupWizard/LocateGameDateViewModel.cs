using WolvenKit.App.ViewModels;
using WolvenKit.Functionality.Services;
using WolvenKit.Models.Wizards;

namespace WolvenKit.ViewModels.Wizards.FirstSetupWizard
{
    public class LocateGameDateViewModel : ViewModelBase
    {
        #region constructors

        public LocateGameDateViewModel(FirstSetupWizardModel firstSetupWizardModel, FirstSetupWizardViewModel firstSetupWizardViewModel)
        {
            FirstSetupWizardModel = firstSetupWizardModel;
            FirstSetupWizardViewModel = firstSetupWizardViewModel;
        }

        #endregion constructors

        #region properties

        /// <summary>
        /// Gets or sets the FirstSetupWizardModel.
        /// </summary>
        public FirstSetupWizardModel FirstSetupWizardModel { get; set; }

        /// <summary>
        /// Gets or sets the FirstSetupWizardViewModel.
        /// </summary>
        public FirstSetupWizardViewModel FirstSetupWizardViewModel { get; set; }


        #endregion properties
    }
}
