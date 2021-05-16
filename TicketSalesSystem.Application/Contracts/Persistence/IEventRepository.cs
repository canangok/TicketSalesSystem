using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSalesSystem.Domain.Entities;

namespace TicketSalesSystem.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
    }
}
