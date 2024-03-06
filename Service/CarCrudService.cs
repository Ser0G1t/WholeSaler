using WholeSaler.Entity;
using WholeSaler.IRepository;
using WholeSaler.IService;

namespace WholeSaler.Service
{
    public class CarCrudService : ICarCrudService
    {
        private readonly ICarRepository _carRepository;

        public CarCrudService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task Delete(long id)
        {
            await _carRepository.Delete(id);
        }

        public async Task<IEnumerable<Car>> FindAll()
        {
            return await _carRepository.FindAll();
        }

        public async Task<Car> GetById(long id)
        {
            return await _carRepository.GetById(id);
        }

        public async Task Insert(Car entity)
        {
            await _carRepository.Insert(entity);
        }

        public async Task Update(long id, Car entity)
        {
            var updatedEntity = await _carRepository.GetById(id);
            updatedEntity.PaletteCapacity = entity.PaletteCapacity;
            await _carRepository.Update(updatedEntity);
        }
    }
}
