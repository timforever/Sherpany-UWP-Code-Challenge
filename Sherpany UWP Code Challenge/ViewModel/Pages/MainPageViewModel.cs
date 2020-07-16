using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Sherpany_UWP_Code_Challange.Interfaces;
using Sherpany_UWP_Code_Challenge.Messages;

namespace Sherpany_UWP_Code_Challenge.ViewModel.Pages
{
    public class MainPageViewModel: ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IKeyManager _keyManager;

        private bool _isAppClosing = false;
        private string _password = "";

        public bool IsAppClosing
        {
            get => _isAppClosing;
            private set => Set(ref _isAppClosing, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public bool IsPasswordSet => _keyManager.IsKeySet();

        public MainPageViewModel(INavigationService navigationService, IKeyManager keyManager)
        {
            _navigationService = navigationService;
            _keyManager = keyManager;
        }

        /// <summary>
        /// This method will kick off the closing of the app.
        /// </summary>
        public async void StartAppClose()
        {
            // Don't trigger this more than once.
            if (IsAppClosing)
                return;

            IsAppClosing = true;
            await Task.Delay(2000);
            Messenger.Default.Send(new CloseAppMessage());
        }

        public void ResetPassword()
        {
            _keyManager.DeleteEncryptionKey();
            RaisePropertyChanged(nameof(IsPasswordSet));
        }

        // If no passcode is set in the vault, the user can enter one and will then be navigated to the DetailPageView
        public ICommand SetPasswordAndNavigateCommand => new RelayCommand<string>(SetPasswordAndNavigate, ValidatePassword);

        private static bool ValidatePassword(string password)
        {
            // Match for exactly 6 digits.
            return Regex.IsMatch(password, @"^\d{6}$");
        }

        private void SetPasswordAndNavigate(string password)
        {
            if (!ValidatePassword(password))
                return;

            _keyManager.SetEncryptionKey(password);

            _navigationService.NavigateTo("SherpanyValuesPageView");
        }

        // If a passcode has already been stored, use this to validate and navigate
        public ICommand VerifyPasswordAndNavigateCommand => new RelayCommand<string>(VerifyPasswordAndNavigate, VerifyPassword);

        private bool VerifyPassword(string password)
        {
            if (!ValidatePassword(password)) return false;

            return IsPasswordSet && password == _keyManager.GetEncryptionKey(false);
        }

        private void VerifyPasswordAndNavigate(string password)
        {
            if (!VerifyPassword(password)) return;

            _navigationService.NavigateTo("SherpanyValuesPageView");
        }
    }
}
