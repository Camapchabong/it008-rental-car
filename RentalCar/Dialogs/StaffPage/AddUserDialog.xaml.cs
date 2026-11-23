using Microsoft.UI.Xaml.Controls;
using RentalCar.Enums;
using RentalCar.Models;

namespace RentalCar.Views.Dialogs;

public sealed partial class AddUserDialog : ContentDialog
{
    public User? NewUser { get; private set; }
    public AddUserDialog()
    {
        InitializeComponent();
    }

    private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {
        if (string.IsNullOrWhiteSpace(FullNameBox.Text) || string.IsNullOrWhiteSpace(AccountBox.Text) || string.IsNullOrWhiteSpace(PasswordBox.Password) || string.IsNullOrWhiteSpace(ConfirmPasswordBox.Password))
        {
            ErrorBar.Message = "Vui lòng điền đầy đủ thông tin.";
            ErrorBar.IsOpen = true;
            args.Cancel = true;
            return;
        }

        if (PasswordBox.Password != ConfirmPasswordBox.Password)
        {
            ErrorBar.Message = "Mật khẩu xác nhận không khớp.";
            ErrorBar.IsOpen = true;
            args.Cancel = true;
            return;
        }

        if (PasswordBox.Password.Length < 8)
        {
            ErrorBar.Message = "Mật khẩu phải có ít nhất 8 ký tự.";
            ErrorBar.IsOpen = true;
            args.Cancel = true;
            return;
        }

        NewUser = new User
        {
            FullName = FullNameBox.Text.Trim(),
            Account = AccountBox.Text.Trim(),
            PasswordHash = PasswordBox.Password,
            Role = (UserRole)RoleBox.SelectedIndex,
            IsActive = ActiveSwitch.IsOn
        };
    }
}
