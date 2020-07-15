using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
    }
}
