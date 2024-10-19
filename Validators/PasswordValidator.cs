using FluentValidation;

namespace AvaloniaTest.Validators
{
    public class PasswordValidator : AbstractValidator<string>
    {
        public PasswordValidator() 
        {
            RuleFor(password => password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
                .MaximumLength(64).WithMessage("Password must not exceed 64 characters")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,64}$").WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character");
        }
    }

}
