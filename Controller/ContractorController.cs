using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WholeSaler.DTO;
using WholeSaler.IService;

namespace WholeSaler.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ContractorController : ControllerBase
    {
        private readonly IContractorCrudService _contractorCrudService;
        private readonly IMapper _mapper;

        public ContractorController(IContractorCrudService contractorCrudService, IMapper mapper)
        {
            _contractorCrudService = contractorCrudService;
            _mapper = mapper;
        }
        [HttpGet("")]
        public async Task<ActionResult> findAll() {
            var contractors = _mapper.Map<IEnumerable<UserAsContractorDTO>>(await _contractorCrudService.GetContractors());
            return Ok(contractors);
        }
    }
}
