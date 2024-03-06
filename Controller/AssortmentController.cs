using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WholeSaler.DTO;
using WholeSaler.Entity;
using WholeSaler.IService;

namespace WholeSaler.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AssortmentController : ControllerBase
    {
        private readonly IAssortmentCrudService _assortmentCrudService;
        private readonly IMapper _mapper;

        public AssortmentController(IAssortmentCrudService assortmentCrudService, IMapper mapper)
        {
            _assortmentCrudService = assortmentCrudService;
            _mapper = mapper;
        }
        //[Authorize(Roles = "manager")]
        [HttpPost("create")]
        public async Task <ActionResult> createAssortment([FromBody] AssortmentDTO assortmentDTO)
        {
            var assortment = _mapper.Map<Assortment>(assortmentDTO);
            await _assortmentCrudService.Insert(assortment);
            return Ok();
        }

        [Authorize(Roles ="user")]
        [HttpGet("")]
        public async Task<ActionResult> FindAll()
        {
            var assortments= await _assortmentCrudService.FindAll();
            return Ok(_mapper.Map<IEnumerable<AssortmentDTO>>(assortments));
        }
        [Authorize(Roles = "user")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Assortment>> GetById([FromRoute] long id)
        {
            var assortment = await _assortmentCrudService.GetById(id);
            return Ok(_mapper.Map<AssortmentDTO>(assortment));
        }
        [Authorize(Roles = "manager")]
        [HttpDelete("delete/id")]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            await _assortmentCrudService.Delete(id);
            return Ok();
        }
        //[Authorize(Roles = "manager")]
        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update([FromRoute] long id, [FromBody] AssortmentDTO assortmentDTO)
        {
            await _assortmentCrudService.Update(id, _mapper.Map<Assortment>(assortmentDTO));
            return Ok();
        }


    }
}
