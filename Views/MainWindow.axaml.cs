using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaTest.ViewModels;
using System;
using System.Linq;

namespace AvaloniaTest.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
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
                var viewModel = DataContext as MainWindowViewModel;

                var errors = viewModel?.GetErrors(nameof(viewModel.Email));
            }
        }

        private void PasswordBox_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if(e.Property.Name == nameof(TextBox.Text))
            {
                var passwordBox = sender as TextBox;
                var viewModel = DataContext as MainWindowViewModel;

                var errors = viewModel?.GetErrors(nameof(viewModel.Password));
            }
        }

        

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            var signUpWindow = new SignupWindow();
            signUpWindow.Show();
        }

    }
}