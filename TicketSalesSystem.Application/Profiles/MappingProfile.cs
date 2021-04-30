using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSalesSystem.Application.Features.Events.Queries.GetEventDetail;
using TicketSalesSystem.Application.Features.Events.Queries.GetEventList;
using TicketSalesSystem.Domain.Entities;

namespace TicketSalesSystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>();
        }
    }
}
