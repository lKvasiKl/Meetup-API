using FluentValidation;
using Meetup_API.Models.Request;

namespace Meetup_API.Validators
{
    public class SpeakerValidator : AbstractValidator<SpeakerRequest>
    {
        public SpeakerValidator()
        {
            RuleFor(e => e.Name).NotNull()
                                .NotEmpty()
                                .WithMessage(m => $"{nameof(m.Name)} should contains at least one symbol");
        }
    }
}
