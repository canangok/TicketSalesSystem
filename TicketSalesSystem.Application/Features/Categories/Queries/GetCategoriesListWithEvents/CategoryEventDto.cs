using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSalesSystem.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class CategoryEventDto //Category Id si ile birlike göre event modeli
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public Guid CategoryId { get; set; }
    
    }
}
