using Microsoft.UI.Xaml.Controls;

namespace RentalCar.Views.Dialogs;

public sealed partial class ChangePasswordDialog : ContentDialog
{
    public string NewPassword => NewPasswordBox.Password;
    public ChangePasswordDialog()
    {
        InitializeComponent();
    }

    private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {
        if (string.IsNullOrWhiteSpace(NewPasswordBox.Password) || string.IsNullOrWhiteSpace(ConfirmPasswordBox.Password))
        {
            ErrorBar.Message = "Vui lòng điền đầy đủ thông tin.";
            ErrorBar.IsOpen = true;
            args.Cancel = true;
            return;
        }
        if (NewPasswordBox.Password != ConfirmPasswordBox.Password)
        {
            ErrorBar.Message = "Mật khẩu xác nhận không khớp.";
            ErrorBar.IsOpen = true;
            args.Cancel = true;
            return;
        }
        if (NewPasswordBox.Password.Length < 8)
        {
            ErrorBar.Message = "Mật khẩu phải có ít nhất 8 ký tự.";
            ErrorBar.IsOpen = true;
            args.Cancel = true;
            return;
        }
    }
}
