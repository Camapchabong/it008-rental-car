using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace RentalCar
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Icon trên thanh tiêu đề cửa sổ (WinUI 3 không tự lấy icon của .exe)
            AppWindow.SetIcon(Path.Combine(AppContext.BaseDirectory, "Assets", "rentalcar.ico"));

            RootFrame.Navigated += (s, e) =>
            {
                var presenter = AppWindow.Presenter as Microsoft.UI.Windowing.OverlappedPresenter;
                if (e.SourcePageType == typeof(Views.LoginPage))
                {
                    presenter?.Restore();                           // thoát phóng to khi đăng xuất
                    AppWindow.Resize(new SizeInt32(1600, 960));     // LoginPage

                    // Đưa cửa sổ vào giữa vùng làm việc của màn hình
                    var area = Microsoft.UI.Windowing.DisplayArea.GetFromWindowId(
                        AppWindow.Id, Microsoft.UI.Windowing.DisplayAreaFallback.Nearest).WorkArea;
                    AppWindow.Move(new PointInt32(
                        area.X + (area.Width - AppWindow.Size.Width) / 2,
                        area.Y + (area.Height - AppWindow.Size.Height) / 2));
                }
                else
                    presenter?.Maximize();                          // MainWindow: toàn màn hình
            };

            RootFrame.Navigate(typeof(Views.LoginPage)); //
        }
    }
}
