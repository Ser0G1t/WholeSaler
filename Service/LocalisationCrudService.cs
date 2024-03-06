using WholeSaler.Entity;
using WholeSaler.IRepository;
using WholeSaler.IService;

namespace WholeSaler.Service
{
    public class LocalisationCrudService : ILocalisationCrudService
    {
        private readonly ILocalisationRepository _repository;

        public LocalisationCrudService(ILocalisationRepository repository)
        {
            _repository = repository;
        }

        public async Task Delete(long id)
        {
           await _repository.Delete(id);
        }

        public async Task<IEnumerable<Localisation>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Localisation> GetById(long id)
        {
            return await _repository.GetById(id);
        }

        public async Task Insert(Localisation entity)
        {
            await _repository.Insert(entity);
        }

        public async Task Update(long id, Localisation entity)
        {
            var updatedEntity = await _repository.GetById(id);
            updatedEntity.Name = entity.Name;
            await _repository.Update(entity);
        }
    }
}
