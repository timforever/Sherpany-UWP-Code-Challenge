using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Sherpany_UWP_Code_Challenge.ViewModel;
using Sherpany_UWP_Code_Challenge.ViewModel.Pages;

namespace Sherpany_UWP_Code_Challenge
{
    /// <summary>
    /// The Main Page of the application.
    /// </summary>
    public sealed partial class MainPageView : Page
    {
        public MainPageView()
        {
            InitializeComponent();
            var viewModelLocator = (ViewModelLocator) Application.Current.Resources["Locator"];
            VM = viewModelLocator.MainPage;
        }

        public MainPageViewModel VM { get; }

        private void OnManipulationStarted(object sender, Windows.UI.Xaml.Input.ManipulationStartedRoutedEventArgs e)
        {
            Button.IsEnabled = false;
            e.Handled = true;
        }

        private void OnManipulationDelta(object sender, Windows.UI.Xaml.Input.ManipulationDeltaRoutedEventArgs e)
        {
            var transform = DragableGrid.RenderTransform as CompositeTransform;
            transform.TranslateX += e.Delta.Translation.X;
            transform.TranslateY += e.Delta.Translation.Y;

            e.Handled = true;
        }

        private void OnManipulationCompleted(object sender, Windows.UI.Xaml.Input.ManipulationCompletedRoutedEventArgs e)
        {
            Button.IsEnabled = true;
            e.Handled = true;
        }
    }
}
