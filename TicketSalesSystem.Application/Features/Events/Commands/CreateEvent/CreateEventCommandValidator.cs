using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketSalesSystem.Application.Contracts.Persistence;

namespace TicketSalesSystem.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is requeired")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is requeired")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(e => e)
             .MustAsync(EventNameAndDateUnique)
             .WithMessage("An Event with the same name and date already exist");
            

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is requeired")
                .NotNull()
                .GreaterThan(0);

        }

        private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken token)
        {
            return !(await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date));
        }
    }
}
