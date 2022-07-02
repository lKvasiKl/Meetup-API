using AutoMapper;
using Business.Exceptions;
using Business.Models;
using Business.Servises.IServices;
using Data.Entities;
using Data.Repositories.IRepositories;

namespace Business.Servises
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IOrganizerRepository _organizerRepository;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IOrganizerRepository organizerRepository,
                            ISpeakerRepository speakerRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _organizerRepository = organizerRepository;
            _speakerRepository = speakerRepository;
            _mapper = mapper;
        }

        public async Task<EventModel> CreateAsync(EventModel eventModel)
        {
            List<OrganizerModel> organizersModel = eventModel.Organizers.ToList();
            var organizers = GetOrganizersListAsync(organizersModel).Result;

            List<SpeakerModel> speakersModel = eventModel.Speakers.ToList();
            var speakers = GetSpeakersListAsync(speakersModel).Result;

            var eventEntity = _mapper.Map<EventModel, Event>(eventModel);
            eventEntity.Organizers = organizers;
            eventEntity.Speakers = speakers;

            eventEntity = await _eventRepository.CreateAsync(eventEntity);

            return _mapper.Map<Event, EventModel>(eventEntity);
        }

        public async Task<List<EventModel>> GetAllAsync()
        {
            var entities = await _eventRepository.GetAllAsync();

            return _mapper.Map<List<Event>, List<EventModel>>(entities);
        }

        public async Task<EventModel> GetByIdAsync(int id)
        {
            var entity = await _eventRepository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new NotFoundException($"{nameof(entity)} with id = {id} not found.");
            }

            return _mapper.Map<Event, EventModel>(entity);
        }

        public async Task UpdateAsync(int id, EventModel updateModel)
        {
            var entityToUpdate = await _eventRepository.GetByIdAsync(id);

            if (entityToUpdate == null)
            {
                throw new NotFoundException($"{nameof(entityToUpdate)} with id = {id} not found.");
            }

            List<OrganizerModel> organizersModel = updateModel.Organizers.ToList();
            var organizers = GetOrganizersListAsync(organizersModel).Result;

            List<SpeakerModel> speakersModel = updateModel.Speakers.ToList();
            var speakers = GetSpeakersListAsync(speakersModel).Result;

            entityToUpdate.Title = updateModel.Title;
            entityToUpdate.Topic = updateModel.Topic;
            entityToUpdate.Description = updateModel.Description;
            entityToUpdate.Schedule = updateModel.Schedule;
            entityToUpdate.DateTime = updateModel.DateTime;
            entityToUpdate.Organizers = organizers;
            entityToUpdate.Speakers = speakers;

            await _eventRepository.UpdateAsync(entityToUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await _eventRepository.GetByIdAsync(id);

            if (entityToDelete == null)
            {
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {id} not found.");
            }

            await _eventRepository.DeleteAsync(entityToDelete);
        }

        private async Task<List<Organizer>> GetOrganizersListAsync(List<OrganizerModel> organizersModel)
        {
            List<Organizer> organizers = new();
            foreach (var organizerModel in organizersModel)
            {
                var organizerEntity = await _organizerRepository.GetByNameAsync(organizerModel.Name);
                if (organizerEntity == null)
                {
                    throw new NotFoundException($"{nameof(organizerEntity)} with name {organizerModel.Name} not found.");
                }

                organizers.Add(organizerEntity);
            }

            return organizers;
        }

        private async Task<List<Speaker>> GetSpeakersListAsync(List<SpeakerModel> speakersModel)
        {
            List<Speaker> speakers = new();
            foreach (var speakerModel in speakersModel)
            {
                var speakerEntity = await _speakerRepository.GetByNameAsync(speakerModel.Name);
                if (speakerEntity == null)
                {
                    throw new NotFoundException($"{nameof(speakerEntity)} with name {speakerModel.Name} not found.");
                }

                speakers.Add(speakerEntity);
            }

            return speakers;
        }
    }
}
