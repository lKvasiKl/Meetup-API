using AutoMapper;
using Business.Models;
using Meetup_API.Models.Request;
using Meetup_API.Models.Responce;

namespace Meetup_API.MappingProfiles
{
    public class OrganizerProfile : Profile
    {
        public OrganizerProfile()
        {
            CreateMap<OrganizerRequest, OrganizerModel>();
            CreateMap<OrganizerModel, OrganizerResponce>();
        }
    }
}
