using AutoMapper;
using Business.Models;
using Meetup_API.Models.Request;
using Meetup_API.Models.Responce;

namespace Meetup_API.MappingProfiles
{
    public class SpeakerProfile : Profile
    {
        public SpeakerProfile()
        {
            CreateMap<SpeakerRequest, SpeakerModel>();
            CreateMap<SpeakerModel, SpeakerResponce>();
        }
    }
}
