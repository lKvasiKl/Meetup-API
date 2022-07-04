using FluentValidation;
using Meetup_API.Models.Request;
using System.Text.RegularExpressions;

namespace Meetup_API.Validators
{
    public class AuthValidator : AbstractValidator<AuthRequest>
    {
        public AuthValidator()
        {
            RuleFor(e => e.Email).EmailAddress()
                                 .NotNull()
                                 .NotEmpty()
                                 .WithMessage(m => $"Invalid {m.Email}");
            RuleFor(e => e.Password).Must(IsValidPassword)
                                    .NotNull()
                                    .NotEmpty()
                                    .WithMessage(m => $"{nameof(m.Password)} must be more than 7 characters long, contain letters of the English alphabet and at least one number");
        }

        private bool IsValidPassword(string password)
        {
            Regex rgx = new("^((?=.*[0-9])(?=.*[a-zA-Z])[0-9a-zA-Z]{8,})$");
            return rgx.IsMatch(password);
        }
    }
}
