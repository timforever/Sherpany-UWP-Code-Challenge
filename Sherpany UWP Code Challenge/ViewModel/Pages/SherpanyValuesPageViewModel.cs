using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using Sherpany_UWP_Code_Challange.Interfaces;
using Sherpany_UWP_Code_Challange.Model;

namespace Sherpany_UWP_Code_Challange.ViewModel.Pages
{
    /// <summary>
    /// The view model for a singular Sherpany Value.
    /// </summary>
    public class SherpanyValueViewModel : ViewModelBase
    {
        private readonly SherpanyValueModel _model;
        private bool _isSelected;

        public SherpanyValueViewModel(SherpanyValueModel model)
        {
            _model = model;
        }

        public string Title => _model.Title;
        public string Description => _model.Description;
        public string Claim => _model.Claim;
        public int Order => _model.Order;

        public bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value);
        }
    }

    /// <summary>
    /// The view model for the SherpanyValuesPageView.
    /// </summary>
    public class SherpanyValuesPageViewModel : ViewModelBase
    {
        private readonly IDummyApiService _apiService;
        private bool _isLoading;
        private ObservableCollection<SherpanyValueViewModel> _values = new ObservableCollection<SherpanyValueViewModel>();

        public SherpanyValuesPageViewModel(IDummyApiService apiService)
        {
            _apiService = apiService;

            LoadSherpanyValues();
        }

        public ObservableCollection<SherpanyValueViewModel> Values
        {
            get => _values;
            set => Set(ref _values, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }

        public async void LoadSherpanyValues()
        {
            IsLoading = true;

            try
            {
                var valueModels = await _apiService.GetValueModelsAsync();
                Values = new ObservableCollection<SherpanyValueViewModel>(
                    valueModels.Select(m => new SherpanyValueViewModel(m))
                               .OrderBy(vm => vm.Order)
                );
            }
            finally
            { IsLoading = false; }
        }
    }
}
