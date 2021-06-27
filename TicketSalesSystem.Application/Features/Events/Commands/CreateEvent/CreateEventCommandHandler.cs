using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketSalesSystem.Application.Contracts.Infrastructure;
using TicketSalesSystem.Application.Contracts.Persistence;
using TicketSalesSystem.Application.Models;
using TicketSalesSystem.Domain.Entities;

namespace TicketSalesSystem.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, IEmailService emailService)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }
            //CreateCommand'den Event'a mapleme yapılıyor. Veritabaı kaydı için entitiye çevriliyor.
            var @event = _mapper.Map<Event>(request);
            @event = await _eventRepository.AddAsync(@event);

            var email = new Email()
            {
                To = "cnngk186@gmail.com",
                Body = $"A new event was created:{request}",
                Subject="A new event"
            };
            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //will be logged
            }

            return @event.EventId;
        }
    }
}
