using WholeSaler.Entity;
using WholeSaler.IRepository;
using WholeSaler.IService;

namespace WholeSaler.Service
{
    public class ContractorCrudService : IContractorCrudService
    {
        private readonly IContractorRepository _contractorRepository;

        public ContractorCrudService(IContractorRepository contractorRepository)
        {
            _contractorRepository = contractorRepository;
        }
        public async Task<IEnumerable<User>> GetContractors()
        {
            return await _contractorRepository.FindAll();
        }
    }
}
