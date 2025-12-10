using FluentValidation;
using OfficeLunch.Application.DTOs.Auth.Request;

namespace OfficeLunch.Application.Validations
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            // Validate username: must not be empty and must have a minimum length
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username cannot be empty.")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters long.");

            // Validate password: cannot be empty
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty.");
        }
    }

}
