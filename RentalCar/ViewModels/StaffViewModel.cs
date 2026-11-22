using RentalCar.Commands;
using RentalCar.Enums;
using RentalCar.Models;
using RentalCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.ViewModels
{
    public class StaffRowViewModel
    {
        private readonly User _user;
        public StaffRowViewModel(User user) => _user = user;

        public string FullName => _user.FullName;
        public string Code => $"NV{_user.UserId:000}";          // 1 → NV001
        public string Account => _user.Account;
        public string RoleText => _user.Role == UserRole.Admin ? "Admin" : "Nhân viên";
        public bool IsActive => _user.IsActive;
        public bool IsLocked => !_user.IsActive;
    }

    public class StaffViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly IUserService _userService;

        public ObservableCollection<StaffRowViewModel> Staff { get; } = new();
        public AsyncRelayCommand LoadCommand { get; }

        public StaffViewModel(IUserService userService)
        {
            _userService = userService;
            LoadCommand = new AsyncRelayCommand(LoadAsync);
        }

        // Lấy danh sách tài khoản từ DB rồi đổ vào bảng
        private async Task LoadAsync()
        {
            var users = await _userService.GetAllAsync();
            Staff.Clear();
            foreach (var u in users)
                Staff.Add(new StaffRowViewModel(u));
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
