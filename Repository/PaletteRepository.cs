using WholeSaler.Context;
using WholeSaler.Entity;
using WholeSaler.IRepository;

namespace WholeSaler.Repository
{
    internal class PaletteRepository : CoreRepository<Palette>, IPaletteRepository
    {
        public PaletteRepository(CoreContext context) : base(context)
        {
        }
    }
}
