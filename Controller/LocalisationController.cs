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
    //[Authorize(Roles = "manager")]
    public class LocalisationController : ControllerBase
    {
        private readonly ILocalisationCrudService _localisationService;
        private readonly IMapper _mapper;
        public LocalisationController(ILocalisationCrudService localisationService, IMapper mapper)
        {
            _localisationService = localisationService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<LocalisationDTO>>> FindAll()
        {
            var localisations = await _localisationService.FindAll();
            return Ok(_mapper.Map<IEnumerable<LocalisationDTO>>(localisations));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Localisation>> GetById([FromQuery] long id)
        {
            var localisation = await _localisationService.GetById(id);
            return Ok(_mapper.Map<LocalisationDTO>(localisation));
        }
        [HttpPost("create")]
        public async Task<ActionResult> Insert([FromBody] LocalisationDTO localisationDTO)
        {
            await _localisationService.Insert(_mapper.Map<Localisation>(localisationDTO));
            return Ok();
        }
        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update([FromRoute] long id, [FromBody] LocalisationDTO localisationDTO)
        {
            await _localisationService.Update(id, _mapper.Map<Localisation>(localisationDTO));
            return Ok();
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            await _localisationService.Delete(id);
            return Ok();
        }


    }
}
