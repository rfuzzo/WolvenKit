using System.Runtime.InteropServices;
using System.Windows;

namespace WPFTestHarness
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string witcherPath = "D:\\Program Files(x86)\\GOG Galaxy\\Games\\The Witcher 3 Wild Hunt\\bin\\x64";
            WKRender.SetWitcherExePath(witcherPath);

            string assetPath = "levels\\island_of_mist\\island_of_mist.w2w";
            if (WKRender.LoadAsset(assetPath))
            {
                System.IntPtr hWnd = new System.Windows.Interop.WindowInteropHelper(App.Current.MainWindow).Handle;
                WKRender.WKRun(Marshal.GetHINSTANCE(GetType().Module), hWnd, (uint)ActualWidth, (uint)ActualHeight);
                //WKRender.WKRun(System.IntPtr.Zero, hWnd, 600, 300);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
