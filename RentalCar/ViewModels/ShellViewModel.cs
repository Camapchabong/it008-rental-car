using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RentalCar.Commands;
using RentalCar.Enums;
using RentalCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.ViewModels
{
    public class ShellViewModel
    {
        private readonly ISessionService _sessionService;
        public event EventHandler? LoggedOutSucceeded;
        public bool IsAdmin => _sessionService.IsAdmin;
        public string UserName => _sessionService.CurrentUser?.FullName ?? string.Empty;
        public string UserRoleText => IsAdmin ? "Quản trị viên" : "Nhân viên";
        public AsyncRelayCommand LogoutCommand { get; }

        // View sẽ gán hàm hiện dialog vào đây
        public Func<Task<bool>>? AskConfirmLogout { get; set; }

        public ShellViewModel(ISessionService sessionService)
        {
            _sessionService = sessionService;
            LogoutCommand = new AsyncRelayCommand(Logout);
        }

        private async Task Logout()
        {
            var confirmed = await AskConfirmLogout!();
            if (!confirmed) return;

            _sessionService.Logout();
            LoggedOutSucceeded?.Invoke(this, EventArgs.Empty);
        }
    }
}
