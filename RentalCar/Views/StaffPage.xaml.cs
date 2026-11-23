using Microsoft.UI;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using RentalCar.Models;
using RentalCar.Services.Interfaces;
using RentalCar.ViewModels;
using System;

namespace RentalCar.Views
{
    public sealed partial class StaffPage : Page
    {
        public StaffViewModel ViewModel { get; }
        private readonly ISessionService _sessionService;
        public StaffPage()
        {
            InitializeComponent();
            ViewModel = App.GetService<StaffViewModel>();
            _sessionService = App.GetService<ISessionService>();
        }

        // Mỗi lần vào trang thì tải lại trang 
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.LoadDataCommand.Execute(null);
        }

        // Hiển thị action khi rê chuột vào dòng
        private void Row_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var row = (Grid)sender;
            row.Background = new SolidColorBrush(Colors.WhiteSmoke);

            var actions = (StackPanel)row.FindName("RowActions");
            actions.Visibility = Visibility.Visible;
        }

        // Hiển thị action khi rê chuột ra khỏi dòng
        private void Row_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            var row = (Grid)sender;
            row.Background = new SolidColorBrush(Colors.Transparent);

            var actions = (StackPanel)row.FindName("RowActions");
            actions.Visibility = Visibility.Collapsed;
        }

        private async void EditInfo_Click(object sender, RoutedEventArgs e)
        {
            // Lấy user từ DataContext của dòng được click
            var user = (User)((FrameworkElement)sender).DataContext;

            // Hiển thị dialog để sửa thông tin
            var dialog = new Dialogs.EditUserDialog(user, _sessionService);
            dialog.XamlRoot = this.XamlRoot;

            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                try
                {
                    await ViewModel.UpdateUserAsync(
                        user.UserId,
                        dialog.UpdatedFullName,
                        dialog.UpdatedRole,
                        dialog.UpdatedIsActive);
                }
                catch (Exception ex)
                {
                    throw new Exception("Cập nhật thông tin tài khoản thất bại: " + ex.Message);
                }
            }
        }

        private async void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialogs.AddUserDialog();
            dialog.XamlRoot = this.XamlRoot;
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                try
                {
                    await ViewModel.AddUserAsync(dialog.NewUser);
                }
                catch (Exception ex)
                {
                    var error = new ContentDialog
                    {
                        Title = "Thêm tài khoản thất bại",
                        Content = "Tên đăng nhập có thể đã tồn tại. Vui lòng kiểm tra lại.",
                        CloseButtonText = "Đóng",
                        XamlRoot = this.XamlRoot
                    };
                }
            }
        }

        private async void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            var user = (User)((FrameworkElement)sender).DataContext;

            var dialog = new Dialogs.ChangePasswordDialog();
            dialog.XamlRoot = this.XamlRoot;

            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                await ViewModel.ChangePasswordAsync(user.UserId, dialog.NewPassword);
            }
        }
    }
}
