using System.Reactive;
using System.Threading.Tasks;
using HandyControl.Controls;
using ReactiveUI;
using WolvenKit.App.ViewModels;
using WolvenKit.Functionality.Services;
using WolvenKit.Models.Wizards;
using WolvenKit.Common;

namespace WolvenKit.ViewModels.Wizards.FirstSetupWizard
{
    public class FinalizeSetupViewModel : ViewModelBase
    {
        #region fields

        public static readonly string bpp = "pack://application:,,,/Resources/Media/Images/Application/BlankProfilePicture.png";

        #endregion fields

        #region constructors

        public FinalizeSetupViewModel(FirstSetupWizardModel firstSetupWizardModel, FirstSetupWizardViewModel firstSetupWizardViewModel)
        {

            FirstSetupWizardModel = firstSetupWizardModel;
            FirstSetupWizardViewModel = firstSetupWizardViewModel;
            
            ControlLoaded = ReactiveCommand.CreateFromTask<ImageSelector>(ControlLoadedExecuteAsync, (imgSelector) => true);
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

        #region commands

        public ReactiveCommand<ImageSelector, Unit> ControlLoaded { get; private set; }

        /// <summary>
        /// Exectues on control loaded event.
        /// </summary>
        private Task ControlLoadedExecuteAsync(ImageSelector imgSelector)
        {
            if (FirstSetupWizardModel.ProfileImageBrush != null)
            {
                imgSelector.SetValue(ImageSelector.UriPropertyKey, new System.Uri(FirstSetupWizardModel.ProfileImageBrushPath, System.UriKind.RelativeOrAbsolute));
                imgSelector.SetValue(ImageSelector.PreviewBrushPropertyKey, FirstSetupWizardModel.ProfileImageBrush);
                imgSelector.SetValue(ImageSelector.HasValuePropertyKey, true);
                imgSelector.SetValue(ImageSelector.IsEnabledProperty, true);
                imgSelector.SetCurrentValue(ImageSelector.ToolTipProperty, FirstSetupWizardModel.ProfileImageBrushPath);
            }
            else
            {
                var uri = new System.Uri(bpp);
                imgSelector.SetValue(ImageSelector.UriPropertyKey, uri);
                var frame = new System.Windows.Media.Imaging.BitmapImage(uri);
                var imgBrush = new System.Windows.Media.ImageBrush(frame);
                imgSelector.SetValue(ImageSelector.PreviewBrushPropertyKey, imgBrush);
                imgSelector.SetValue(ImageSelector.HasValuePropertyKey, true);
                imgSelector.SetValue(ImageSelector.IsEnabledProperty, false);
                imgSelector.SetCurrentValue(ImageSelector.ToolTipProperty, bpp);

                FirstSetupWizardModel.ProfileImageBrush = imgBrush;
                FirstSetupWizardModel.ProfileImageBrushPath = bpp;
            }

            if (string.IsNullOrEmpty(FirstSetupWizardModel.Author))
                FirstSetupWizardModel.Author = "RedModdingUser";
            if (string.IsNullOrEmpty(FirstSetupWizardModel.Email))
                FirstSetupWizardModel.Email = "contact@redmodding.org";

            return Task.CompletedTask;
        }

        #endregion
    }
}
