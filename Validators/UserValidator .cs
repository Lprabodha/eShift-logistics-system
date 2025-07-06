using eShift_Logistics_System.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Validators
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Name is required.")
                .Must(name => !string.IsNullOrWhiteSpace(name))
                .WithMessage("First name cannot be whitespace.")
                .MaximumLength(100).WithMessage("Name must be under 100 characters.");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .Must(email => !string.IsNullOrWhiteSpace(email?.Trim()))
                    .WithMessage("Email is required.")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                    .WithMessage("Enter a valid email address.")
                .MaximumLength(100)
                    .WithMessage("Email must be under 100 characters.");


            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("Password is required.")
                .Must(p => !string.IsNullOrWhiteSpace(p)).WithMessage("Password cannot be whitespace.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(20).WithMessage("Phone number must be under 20 characters.")
                .Matches(@"^\+?[0-9\- ]*$").WithMessage("Phone number can only contain digits, spaces, dashes, or leading +.")
                .When(x => !string.IsNullOrWhiteSpace(x.Phone));

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.PasswordHash).WithMessage("Passwords do not match.");
        }
    }
}
