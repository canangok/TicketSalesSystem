using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSalesSystem.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQuery : IRequest<List<CategoryEventListVm>>
    {
        public bool IncludeHistory { get; set; } //geçmişi dahil etme seçeneği,tüm olaylar mı yoksa yalnıza gelecekte oanları mı almak istersinz
    }
}
