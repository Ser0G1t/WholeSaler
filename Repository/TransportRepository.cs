using WholeSaler.Context;
using WholeSaler.Entity;
using WholeSaler.IRepository;

namespace WholeSaler.Repository
{
    internal class TransportRepository : CoreRepository<Transport>, ITransportRepository
    {
        public TransportRepository(CoreContext context) : base(context)
        {
        }
    }
}
