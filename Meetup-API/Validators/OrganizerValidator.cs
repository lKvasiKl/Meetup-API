using FluentValidation;
using Meetup_API.Models.Request;
using System.Text.RegularExpressions;

namespace Meetup_API.Validators
{
    public class OrganizerValidator : AbstractValidator<OrganizerRequest>
    {
        public OrganizerValidator()
        {
            RuleFor(e => e.Name).NotNull()
                                .NotEmpty()
                                .WithMessage(m => $"{nameof(m.Name)} should contains at least one symbol");
        }
    }
}
