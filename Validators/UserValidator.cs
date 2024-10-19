using AvaloniaTest.Models;
using FluentValidation;

namespace AvaloniaTest.Validators
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator() 
        {
            RuleFor(user => user.Email)
                .SetValidator(new EmailValidator());

            RuleFor(user => user.Password)
                .SetValidator(new PasswordValidator());
        }
    }
}
