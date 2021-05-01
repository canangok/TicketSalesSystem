using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketSalesSystem.Application.Contracts.Persistence;
using TicketSalesSystem.Domain.Entities;

namespace TicketSalesSystem.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            //CreateCommand'den  Event'a mapleme yapılıyor. Veeitabaıkaydı için entitiye çevrilmesi lazım.
            var @event = _mapper.Map<Event>(request);
            @event = await _eventRepository.AdddAsync(@event);
            return @event.EventId;
        }
    }
}
