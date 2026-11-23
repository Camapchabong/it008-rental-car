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

    public class StaffViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly IUserService _userService;

        public ObservableCollection<User> StaffCollection { get; } = new();
        public AsyncRelayCommand LoadDataCommand { get; }

        public StaffViewModel(IUserService userService)
        {
            _userService = userService;
            LoadDataCommand = new AsyncRelayCommand(LoadDataAsync);
        }

        // Lấy danh sách tài khoản từ DB rồi đổ vào bảng
        private async Task LoadDataAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            StaffCollection.Clear();
            foreach(var u in users)
            {
                StaffCollection.Add(u);
            }
        }

        // Update thông tin tài khoản
        public async Task UpdateUserAsync(int userId, string fullName, UserRole role, bool isActive)
        {
            await _userService.UpdateUserAsync(userId, fullName, role, isActive);
            await LoadDataAsync();
        }

        // Add new account
        public async Task AddUserAsync(User newUser)
        {     
            await _userService.AddUserAsync(newUser);
            StaffCollection.Add(newUser);
        }

        // Change password
        public async Task ChangePasswordAsync(int userId, string newPassword)
        {
            await _userService.ChangePasswordAsync(userId, newPassword);
            await LoadDataAsync();
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
