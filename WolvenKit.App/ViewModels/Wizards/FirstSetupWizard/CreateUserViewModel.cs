using Catel;
using Catel.MVVM;
using WolvenKit.Models.Wizards;

namespace WolvenKit.ViewModels.Wizards.FirstSetupWizard
{
    public class CreateUserViewModel : ViewModelBase
    {
        #region constructors

        public CreateUserViewModel(FirstSetupWizardModel firstSetupWizardModel)
        {
            Argument.IsNotNull(() => firstSetupWizardModel);

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
