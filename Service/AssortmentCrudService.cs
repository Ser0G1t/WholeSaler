using WholeSaler.Context;
using WholeSaler.Entity;
using WholeSaler.Exceptions;
using WholeSaler.IRepository;
using WholeSaler.IService;
namespace WholeSaler.Service
{
    public class AssortmentCrudService : IAssortmentCrudService
    {
        private readonly IAssortmentRepository _repository;
        private readonly CoreContext _context;

        public AssortmentCrudService(IAssortmentRepository repository, CoreContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Delete(long id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Assortment>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Assortment> GetById(long id)
        {
            return await _repository.GetById(id);
        }

        public async Task Insert(Assortment entity)
        {
            nameValidator(entity);
            await _repository.Insert(entity);
        }

        public async Task Update(long id, Assortment entity)
        {
            var updatedEntity = await _repository.GetById(id);
            if (entity.Name != updatedEntity.Name)
            {
                nameValidator(entity);
            }
            updatedEntity.Name = entity.Name;
            updatedEntity.Description = entity.Description;
            updatedEntity.Price = entity.Price;
            updatedEntity.Quantity = entity.Quantity;
            updatedEntity.type = entity.type;
            await _repository.Update(entity);
        }
        private void nameValidator(Assortment entity)
        {
            var doesNameExist = _context.assortments.FirstOrDefault(assortment => assortment.Name == entity.Name) is not null;
            if (doesNameExist)
            {
                throw new AssortmentAlreadyExist("Assortment with this name already exist !");
            }
        }
    }
}
