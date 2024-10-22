using Avalonia;
using Avalonia.Controls;
using AvaloniaTest.ViewModels;

namespace AvaloniaTest;

public partial class SignupWindow : Window
{
    public SignupWindow()
    {
        InitializeComponent();

        var emailBox = this.FindControl<TextBox>("emailBox");
        emailBox.PropertyChanged += EmailBox_PropertyChanged;

        var passwordBox = this.FindControl<TextBox>("passwordBox");
        passwordBox.PropertyChanged += PasswordBox_PropertyChanged;

    }

    private void EmailBox_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property.Name == nameof(TextBox.Text))
        {
            var emailBox = sender as TextBox;
            var viewModel = DataContext as SignupWindowViewModel;

            var errors = viewModel?.GetErrors(nameof(viewModel.Email));
        }
    }

    private void PasswordBox_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property.Name == nameof(TextBox.Text))
        {
            var passwordBox = sender as TextBox;
            var viewModel = DataContext as SignupWindowViewModel;

            var errors = viewModel?.GetErrors(nameof(viewModel.Password));
        }
    }
}