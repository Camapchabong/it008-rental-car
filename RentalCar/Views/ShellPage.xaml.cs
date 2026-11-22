using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using RentalCar.Services;
using RentalCar.Services.Interfaces;
using RentalCar.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace RentalCar.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; }

        public ShellPage()
        {
            InitializeComponent();
            ViewModel = App.GetService<ShellViewModel>();

            ViewModel.LoggedOutSucceeded += OnLoggedOutSucceeded;
            ViewModel.AskConfirmLogout = ConfirmLogoutAsync;
        }

        private void OnLoggedOutSucceeded(object? sender, EventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
            Frame.BackStack.Clear();
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItemContainer != null)
            {
                var selectedItem = args.SelectedItemContainer.Tag.ToString();
                switch (selectedItem)
                {
                    case "Dashboard":
                        ContentFrame.Navigate(typeof(DashboardPage));
                        break;
                    case "Cars":
                        ContentFrame.Navigate(typeof(CarsPage));
                        break;
                    case "Parking":
                        ContentFrame.Navigate(typeof(ParkingPage));
                        break;
                    case "Customers":
                        ContentFrame.Navigate(typeof(CustomersPage));
                        break;
                    case "Contracts":
                        ContentFrame.Navigate(typeof(ContractsPage));
                        break;
                    case "Payments":
                        ContentFrame.Navigate(typeof(PaymentsPage));
                        break;
                    case "Reports":
                        ContentFrame.Navigate(typeof(ReportsPage));
                        break;
                    case "Settings":
                        ContentFrame.Navigate(typeof(SettingsPage));
                        break;
                    case "Users":
                        ContentFrame.Navigate(typeof(StaffPage));
                        break;
                }
            }
        }

        private async Task<bool> ConfirmLogoutAsync()
        {
            var dialog = new ContentDialog
            {
                Title = "Xác nhận đăng xuất",
                Content = "Bạn có chắc muốn đăng xuất khỏi tài khoản này?",
                DefaultButton = ContentDialogButton.Primary,
                PrimaryButtonText = "Đăng xuất",
                CloseButtonText = "Hủy",
                PrimaryButtonStyle = (Style)Application.Current.Resources["AccentButtonStyle"], // luôn xanh
                XamlRoot = XamlRoot,
                Style = (Style)Application.Current.Resources["DefaultContentDialogStyle"]
            };
            var result = await dialog.ShowAsync();
            return result == ContentDialogResult.Primary;
        }

    }
}
