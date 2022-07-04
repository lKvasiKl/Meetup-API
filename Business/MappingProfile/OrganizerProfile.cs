using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.MappingProfile
{
    public class OrganizerProfile : Profile
    {
        public OrganizerProfile()
        {
            CreateMap<OrganizerModel, Organizer>();
            CreateMap<Organizer, OrganizerModel>();
        }
    }
}
