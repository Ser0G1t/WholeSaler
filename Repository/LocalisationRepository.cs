using Microsoft.EntityFrameworkCore;
using WholeSaler.Context;
using WholeSaler.Entity;
using WholeSaler.IRepository;

namespace WholeSaler.Repository
{
    public class LocalisationRepository : CoreRepository<Localisation>, ILocalisationRepository
    {
        public LocalisationRepository(CoreContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<Localisation>> FindAll()
        {
            return await _context.Localisations.Include(loc => loc.Assortments).
                ToListAsync();
        }
    }
}
