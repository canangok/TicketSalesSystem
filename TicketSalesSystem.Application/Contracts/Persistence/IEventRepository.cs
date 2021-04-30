using System;
using System.Collections.Generic;
using TicketSalesSystem.Domain.Entities;

namespace TicketSalesSystem.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
    }
}
