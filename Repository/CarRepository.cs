using WholeSaler.Context;
using WholeSaler.Entity;
using WholeSaler.IRepository;

namespace WholeSaler.Repository
{
    internal class CarRepository : CoreRepository<Car>, ICarRepository
    {
        public CarRepository(CoreContext context) : base(context)
        {
        }
    }
}
