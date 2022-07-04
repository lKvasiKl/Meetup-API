using FluentValidation;
using Meetup_API.Models.Request;

namespace Meetup_API.Validators
{
    public class EventValidator : AbstractValidator<EventRequest>
    {
        public EventValidator()
        {
            RuleFor(e => e.Title).NotNull()
                                 .NotEmpty()
                                 .WithMessage(m => $"{nameof(m.Title)} should contains at least one symbol");
            RuleFor(e => e.Topic).NotNull()
                                 .NotEmpty()
                                 .WithMessage(m => $"{nameof(m.Topic)} should contains at least one symbol");
            RuleFor(e => e.Description).NotNull()
                                       .NotEmpty()
                                       .WithMessage(m => $"{nameof(m.Description)} should contains at least one symbol");
            RuleFor(e => e.Schedule).NotNull()
                                    .NotEmpty()
                                    .WithMessage(m => $"{nameof(m.Schedule)} should contains at least one symbol");
            RuleFor(e => e.DateTime).NotNull()
                                    .NotEmpty()
                                    .WithMessage(m => $"{nameof(m.DateTime)} should match the type yyyy-dd-mmThh:mm");
            RuleFor(e => e.Place).NotNull()
                                 .NotEmpty()
                                 .WithMessage(m => $"{nameof(m.Place)} should contains at least one symbol");
            RuleFor(e => e.Organizers).NotNull()
                                      .NotEmpty()
                                      .WithMessage(m => $"{nameof(m.Organizers)} should contains at least one Organizer");
            RuleFor(e => e.Speakers).NotNull()
                                    .NotEmpty()
                                    .WithMessage(m => $"{nameof(m.Speakers)} should contains at least one Speaker");

        }
    }
}
