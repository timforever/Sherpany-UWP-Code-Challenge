using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Sherpany_UWP_Code_Challange.ViewModel.Pages;
using Sherpany_UWP_Code_Challenge.ViewModel;

namespace Sherpany_UWP_Code_Challange.View.Pages
{
    /// <summary>
    /// This page loads values from the DummyApiService.
    /// </summary>
    public sealed partial class SherpanyValuesPageView : Page
    {
        public SherpanyValuesPageView()
        {
            InitializeComponent();
            var viewModelLocator = (ViewModelLocator) Application.Current.Resources["Locator"];
            VM = viewModelLocator.ValuesPageViewModel;
        }

        public SherpanyValuesPageViewModel VM { get; }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var itemVm in e.RemovedItems.OfType<SherpanyValueViewModel>())
            {
                itemVm.IsSelected = false;
            }

            foreach (var itemVm in e.AddedItems.OfType<SherpanyValueViewModel>())
            {
                itemVm.IsSelected = true;
            }
        }
    }
}
