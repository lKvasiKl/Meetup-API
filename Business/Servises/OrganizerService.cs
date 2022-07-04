using AutoMapper;
using Business.Exceptions;
using Business.Models;
using Business.Servises.IServices;
using Data.Entities;
using Data.Repositories.IRepositories;

namespace Business.Servises
{
    public class OrganizerService : IOrganizerService
    {
        private readonly IOrganizerRepository _organizerRepository;
        private readonly IMapper _mapper;

        public OrganizerService(IOrganizerRepository organizerRepository, IMapper mapper)
        {
            _organizerRepository = organizerRepository;
            _mapper = mapper;
        }

        public async Task<OrganizerModel> CreateAsync(OrganizerModel organizerModel)
        {
            var organizer = await _organizerRepository.GetByNameAsync(organizerModel.Name);

            if (organizer != null)
            {
                throw new BadRequestException($"{nameof(organizer)} with name {organizerModel.Name} already exists.");
            }
            var entity = _mapper.Map<OrganizerModel, Organizer>(organizerModel);
            entity = await _organizerRepository.CreateAsync(entity);

            return _mapper.Map<Organizer, OrganizerModel>(entity);
        }

        public async Task<List<OrganizerModel>> GetAllAsync()
        {
            var entities = await _organizerRepository.GetAllAsync();

            return _mapper.Map<List<Organizer>, List<OrganizerModel>>(entities);
        }

        public async Task<OrganizerModel> GetByIdAsync(int id)
        {
            var entity = await _organizerRepository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new NotFoundException($"{nameof(entity)} with id = {id} not found.");
            }

            return _mapper.Map<Organizer, OrganizerModel>(entity);
        }

        public async Task UpdateAsync(int id, OrganizerModel updateModel)
        {
            var entityToUpdate = await _organizerRepository.GetByIdAsync(id);

            if (entityToUpdate == null)
            {
                throw new NotFoundException($"{nameof(entityToUpdate)} with id = {id} not found.");
            }
            entityToUpdate.Name = updateModel.Name;
            await _organizerRepository.UpdateAsync(entityToUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await _organizerRepository.GetByIdAsync(id);

            if (entityToDelete == null)
            {
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {id} not found.");
            }
            await _organizerRepository.DeleteAsync(entityToDelete);
        }
    }
}
