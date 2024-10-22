using AvaloniaTest.Models;
using FluentValidation;

namespace AvaloniaTest.Validators.Users
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(UserModel => UserModel.Email)
                .NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("Invalid email address")
                .MaximumLength(320).WithMessage("Email must not exceed 320 characters");

            RuleFor(UserModel => UserModel.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
                .MaximumLength(64).WithMessage("Password must not exceed 64 characters")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,64}$").WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character");
        }      
    }
}
