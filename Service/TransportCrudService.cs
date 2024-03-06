using WholeSaler.Entity;
using WholeSaler.IRepository;
using WholeSaler.IService;

namespace WholeSaler.Service
{
    public class TransportCrudService : ITransportCrudService
    {
        private readonly ITransportRepository _transportRepository;

        public TransportCrudService(ITransportRepository transportRepository)
        {
            _transportRepository = transportRepository;
        }

        public async Task Delete(long id)
        {
            await _transportRepository.Delete(id);
        }

        public async Task<IEnumerable<Transport>> FindAll()
        {
            return await _transportRepository.FindAll();
        }

        public async Task<Transport> GetById(long id)
        {
            return await _transportRepository.GetById(id);
        }

        public async Task Insert(Transport entity)
        {
            await _transportRepository.Insert(entity);
        }

        public async Task Update(long id, Transport entity)
        {
            var updatedEntity = await _transportRepository.GetById(id);
            updatedEntity.Car=entity.Car;
            await _transportRepository.Update(updatedEntity);
        }
    }
}
