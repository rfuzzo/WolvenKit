using System.Windows.Media;
using WolvenKit.App.ViewModels;

namespace WolvenKit.ViewModels.Shell
{
    public class PaneViewModel : ViewModelBase
    {


        #region fields

        #endregion fields

        #region constructors

        public PaneViewModel()
        {
        }

        #endregion constructors

        #region Properties

        public string ContentId { get; set; }

        public ImageSource IconSource
        {
            get;
            protected set;
        }

        public bool IsActive { get; set; }

        public bool IsSelected { get; set; }

        public new string Title { get; set; }

        #endregion Properties
    }
}
