using AutoMapper;
using Business.Exceptions;
using Business.Models;
using Business.Servises.IServices;
using Data.Entities;
using Data.Repositories.IRepositories;

namespace Business.Servises
{
    public class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerRepository _speakerRepository;
        private readonly IMapper _mapper;

        public SpeakerService(ISpeakerRepository speakerRepository, IMapper mapper)
        {
            _speakerRepository = speakerRepository;
            _mapper = mapper;
        }

        public async Task<SpeakerModel> CreateAsync(SpeakerModel speakerModel)
        {
            var speaker = await _speakerRepository.GetByNameAsync(speakerModel.Name);

            if (speaker != null)
            {
                throw new BadRequestException($"{nameof(speaker)} with name {speakerModel.Name} already exists.");
            }
            var entity = _mapper.Map<SpeakerModel, Speaker>(speakerModel);
            entity = await _speakerRepository.CreateAsync(entity);

            return _mapper.Map<Speaker, SpeakerModel>(entity);
        }

        public async Task<List<SpeakerModel>> GetAllAsync()
        {
            var entities = await _speakerRepository.GetAllAsync();

            return _mapper.Map<List<Speaker>, List<SpeakerModel>>(entities);
        }

        public async Task<SpeakerModel> GetByIdAsync(int id)
        {
            var entity = await _speakerRepository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new NotFoundException($"{nameof(entity)} with id = {id} not found.");
            }

            return _mapper.Map<Speaker, SpeakerModel>(entity);
        }

        public async Task UpdateAsync(int id, SpeakerModel updateModel)
        {
            var entityToUpdate = await _speakerRepository.GetByIdAsync(id);

            if (entityToUpdate == null)
            {
                throw new NotFoundException($"{nameof(entityToUpdate)} with id = {id} not found.");
            }
            entityToUpdate.Name = updateModel.Name;
            await _speakerRepository.UpdateAsync(entityToUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await _speakerRepository.GetByIdAsync(id);

            if (entityToDelete == null)
            {
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {id} not found.");
            }
            await _speakerRepository.DeleteAsync(entityToDelete);
        }
    }
}
