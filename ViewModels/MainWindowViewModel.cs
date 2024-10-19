using AvaloniaTest.Models;
using AvaloniaTest.Validators;
using FluentValidation;

namespace AvaloniaTest.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private UserModel _userModel = new();
        private readonly UserValidator _userValidator = new();


        public string Email
        {
            get { return _userModel.Email; }
            set
            {
                _userModel.Email = value;
                OnPropertyChanged(nameof(Email));
                ValidateInput(nameof(Email));
                
            }
        }

        public string Password
        {
            get { return _userModel.Password; }
            set
            {
                _userModel.Password = value;
                OnPropertyChanged(nameof(Password));
                ValidateInput(nameof(Password));
            }
        }

        private void ValidateInput(string propertyName)
        {
            var result = _userValidator.Validate(_userModel, options => options.IncludeProperties(propertyName));

            ClearErrors(propertyName);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    AddError(propertyName, error.ErrorMessage);
                }
            }
        }
    }
}
