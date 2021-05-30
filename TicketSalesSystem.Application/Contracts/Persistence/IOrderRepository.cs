using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSalesSystem.Domain.Entities;

namespace TicketSalesSystem.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<int> GetTotalCountOfOrdersForMonth(DateTime date);
        Task<List<Order>> GetPagedOrdersForMonth(DateTime date,int page,int size);
    }
}
