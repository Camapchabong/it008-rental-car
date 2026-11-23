using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using RentalCar.Enums;
using RentalCar.Models;
using RentalCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace RentalCar.Views.Dialogs;

public sealed partial class EditUserDialog : ContentDialog
{
    public string UpdatedFullName => FullNameBox.Text.Trim();
    public UserRole UpdatedRole => (UserRole)RoleBox.SelectedIndex;
    public bool UpdatedIsActive => ActiveSwitch.IsOn;
    public EditUserDialog()
    {
        InitializeComponent();
    }
    public EditUserDialog(User selectedUser, ISessionService session)
    {
        InitializeComponent();

        AccountBox.Text = selectedUser.Account;
        FullNameBox.Text = selectedUser.FullName;
        RoleBox.SelectedIndex = (int)selectedUser.Role;
        ActiveSwitch.IsOn = selectedUser.IsActive;

        bool isSelf = selectedUser.UserId == session.CurrentUser?.UserId;
        RoleBox.IsEnabled = isSelf ? false : true;
        ActiveSwitch.IsEnabled = isSelf ? false : true;
    }

    private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {
        if (string.IsNullOrWhiteSpace(FullNameBox.Text))
        {
            ErrorBar.Message = "Họ tên không được để trống.";
            ErrorBar.IsOpen = true;
            args.Cancel = true;
            return;
        }
    }
}
