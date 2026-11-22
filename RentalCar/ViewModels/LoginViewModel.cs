using RentalCar.Commands;
using RentalCar.Services.Interfaces;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace RentalCar.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly IAuthService _authService;
        private readonly ISessionService _sessionService;

        public event EventHandler? LoginSucceeded;

        public AsyncRelayCommand LoginCommand { get; }
        public LoginViewModel(IAuthService authService, ISessionService sessionService)
        {
            _authService = authService;
            _sessionService = sessionService;
            LoginCommand = new AsyncRelayCommand(LoginAsync, CanLogin);
        }

        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        // Password
        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        // Error Message
        private string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        // Loading
        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        // Lỗi ô tên đăng nhập
        private string _usernameError = string.Empty;
        public string UsernameError
        {
            get => _usernameError;
            set
            {
                _usernameError = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasUsernameError));
            }
        }

        public bool HasUsernameError => !string.IsNullOrEmpty(UsernameError);

        // Lỗi ô mật khẩu
        private string _passwordError = string.Empty;
        public string PasswordError
        {
            get => _passwordError;
            set
            {
                _passwordError = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasPasswordError));
            }
        }
        public bool HasPasswordError => !string.IsNullOrEmpty(PasswordError);

        // Bật / tắt InfoBar
        private bool _hasLoginError;
        public bool HasLoginError
        {
            get => _hasLoginError;
            set
            {
                _hasLoginError = value;
                OnPropertyChanged();
            }
        }

        // Kiểm tra dữ liệu nhập
        private bool Validate()
        {
            UsernameError = string.IsNullOrWhiteSpace(Username) ? "Vui lòng nhập tên đăng nhập."
                          : Username.Trim().Length < 3 ? "Tên đăng nhập phải có ít nhất 3 ký tự."
                          : string.Empty;

            PasswordError = string.IsNullOrEmpty(Password) ? "Vui lòng nhập mật khẩu."
                          : Password.Length < 8 ? "Mật khẩu phải có ít nhất 8 ký tự."
                          : string.Empty;

            return !HasUsernameError && !HasPasswordError;
        }

        // Logic ViewModel Command
        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password) && !IsLoading;
        }

        private async Task LoginAsync()
        {
            ErrorMessage = string.Empty;
            HasLoginError = false;

            if (!Validate()) return;

            IsLoading = true;

            try
            {

                var user = await _authService.LoginAsync(Username, Password);
                if (user == null)
                {
                    ErrorMessage = "Vui lòng kiểm tra lại tài khoản hoặc mật khẩu!";
                    HasLoginError = true;
                    return;
                }

                // Đăng nhập thành công và lưu lại user vào SessionService
                _sessionService.SetUser(user);

                // Sự kiện đăng nhập thành công
                LoginSucceeded?.Invoke(this, EventArgs.Empty);

            }

            catch (Exception ex)
            {
                ErrorMessage = "Đã xảy ra lỗi khi đăng nhập!";
                HasLoginError = true;
                Debug.WriteLine(ex);
            }

            finally
            {
                IsLoading = false;
            }

        }

        // INotifyPropertyChanged
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
