using WholeSaler.Context;
using WholeSaler.Entity;
using WholeSaler.IRepository;

namespace WholeSaler.Repository
{
    public class AssortmentRepository : CoreRepository<Assortment>, IAssortmentRepository
    {
        public AssortmentRepository(CoreContext context) : base(context)
        {

        }
    }
}
