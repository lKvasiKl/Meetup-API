using AutoMapper;
using Business.Models;
using Meetup_API.Models.Request;
using Meetup_API.Models.Responce;

namespace Meetup_API.MappingProfiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventRequest, EventModel>();
            CreateMap<EventModel, EventResponce>();
        }
    }
}
