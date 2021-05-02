using System;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using WolvenKit.App.ViewModels;
using WolvenKit.Functionality.Services;
using WolvenKit.Common.Model;
using WolvenKit.MVVM.Model.ProjectManagement.Project;

namespace WolvenKit.ViewModels.Wizards.PublishWizard
{
    public class W3PackSettingsViewModel : ViewModelBase
    {
        public W3PackSettingsViewModel(
            IProjectManager projectManager)
        {
            

            if (projectManager?.ActiveProject is Tw3Project tw3p)
            {
                WitcherPackSettings = tw3p.PackSettings;
            }

            AllModChanged = ReactiveCommand.CreateFromTask<bool>(AllModChangedExecutedAsync);
            AllDlcChanged = ReactiveCommand.CreateFromTask<bool>(AllDlcChangedExecutedAsync);
        }

        #region Properties

        public string[] PackerSource => new string[] { "DLC", "MOD" };

        /// <summary>
        /// Gets or sets the WitcherPackSettings.
        /// </summary>
        public WitcherPackSettings WitcherPackSettings { get; set; }

        #endregion Properties

        #region Commands

        public ReactiveCommand<bool, Unit> AllModChanged { get; }

        public ReactiveCommand<bool, Unit> AllDlcChanged { get; }

        private Task AllModChangedExecutedAsync(bool value)
        {
            foreach (var property in WitcherPackSettings.GetType().GetProperties())
            {
                if (property.Name.StartsWith("mod", StringComparison.InvariantCultureIgnoreCase))
                {
                    property.SetValue(WitcherPackSettings, value);
                }
            }
            RaisePropertyChanged(nameof(WitcherPackSettings));
            return Task.CompletedTask;
        }

        private Task AllDlcChangedExecutedAsync(bool value)
        {
            foreach (var property in WitcherPackSettings.GetType().GetProperties())
            {
                if (property.Name.StartsWith("dlc", StringComparison.InvariantCultureIgnoreCase))
                {
                    property.SetValue(WitcherPackSettings, value);
                }
            }
            RaisePropertyChanged(nameof(WitcherPackSettings));
            return Task.CompletedTask;
        }

        #endregion Commands
    }
}
