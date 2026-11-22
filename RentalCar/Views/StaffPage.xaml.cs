using Microsoft.UI;
using Microsoft.UI.Input;using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using RentalCar.ViewModels;

namespace RentalCar.Views
{
    public sealed partial class StaffPage : Page
    {
        public StaffViewModel ViewModel { get; }

        public StaffPage()
        {
            InitializeComponent();
            ViewModel = App.GetService<StaffViewModel>();
        }

        // M?i l?n vào trang thì t?i l?i danh sách
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.LoadCommand.Execute(null);
        }

        // Chu?t ?i vào 1 dòng: tô n?n xám nh?t + hi?n nút chìa khóa / s?a
        private void Row_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var row = (Grid)sender;
            row.Background = new SolidColorBrush(Colors.WhiteSmoke);

            var actions = (StackPanel)row.FindName("RowActions");
            actions.Visibility = Visibility.Visible;
        }

        // Chu?t r?i kh?i dòng: tr? l?i nh? c?
        private void Row_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            var row = (Grid)sender;
            row.Background = new SolidColorBrush(Colors.Transparent);

            var actions = (StackPanel)row.FindName("RowActions");
            actions.Visibility = Visibility.Collapsed;
        }
    }
}
