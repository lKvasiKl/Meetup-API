﻿using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.MappingProfile
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventModel, Event>();
            CreateMap<Event, EventModel>();
        }
    }
}
