using AutoMapper;
using Business.Models;
using Meetup_API.Models.Request;

namespace Meetup_API.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AuthRequest, AuthModel>();
        }
    }
}
