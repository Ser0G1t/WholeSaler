using WholeSaler.Context;
using WholeSaler.Entity;
using WholeSaler.IRepository;

namespace WholeSaler.Repository
{
    public class ContractorRepository : CoreRepository<User>, IContractorRepository
    {
        public ContractorRepository(CoreContext context) : base(context)
        {
        }
    }
}
