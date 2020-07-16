﻿using GalaSoft.MvvmLight;
using Sherpany_UWP_Code_Challange.Interfaces;

namespace Sherpany_UWP_Code_Challange.ViewModel.Pages
{
    public class SherpanyValuesPageViewModel : ViewModelBase
    {
        private readonly IDummyApiService _apiService;

        public SherpanyValuesPageViewModel(IDummyApiService apiService)
        {
            _apiService = apiService;
        }
    }
}
