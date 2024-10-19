using FluentValidation;

namespace AvaloniaTest.Validators
{
    public class EmailValidator : AbstractValidator<string>
    {
        public EmailValidator()
        {
            RuleFor(email => email)
                .NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("Invalid email address")
                .MaximumLength(320).WithMessage("Email must not exceed 320 characters");
        }
    }
}
