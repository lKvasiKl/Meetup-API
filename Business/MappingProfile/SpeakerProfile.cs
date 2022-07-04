using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.MappingProfile
{
    public class SpeakerProfile : Profile
    {
        public SpeakerProfile()
        {
            CreateMap<SpeakerModel, Speaker>();
            CreateMap<Speaker, SpeakerModel>();
        }
    }
}
