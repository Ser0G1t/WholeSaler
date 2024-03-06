using WholeSaler.Entity;
using WholeSaler.IRepository;
using WholeSaler.IService;

namespace WholeSaler.Service
{
    public class PaletteCrudService : IPalleteCrudService
    {
        private readonly IPaletteRepository _paletteRepository;

        public PaletteCrudService(IPaletteRepository paletteRepository)
        {
            _paletteRepository = paletteRepository;
        }

        public async Task Delete(long id)
        {
            await _paletteRepository.Delete(id);
        }

        public async Task<IEnumerable<Palette>> FindAll()
        {
            return await _paletteRepository.FindAll();
        }

        public async Task<Palette> GetById(long id)
        {
            return await _paletteRepository.GetById(id);
        }

        public async Task Insert(Palette entity)
        {
            await _paletteRepository.Insert(entity);
        }

        public Task Update(long id, Palette entity)
        {
            throw new NotImplementedException();
        }
    }
}
