using Microsoft.AspNetCore.Mvc;
using WholeSaler.ApiProvider;

namespace WholeSaler.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CeidgController : ControllerBase
    {
        private readonly ICEIDGApiProvider _CEIDGApiProvider;

        public CeidgController(ICEIDGApiProvider CEIDGApiProvider)
        {
            _CEIDGApiProvider = CEIDGApiProvider;
        }
        [HttpGet("nip/{nip}")]
        public async Task<ActionResult> checkNip([FromRoute] string nip)
        {
            var company= await _CEIDGApiProvider.checkNip(nip);
            if(company is null)
            {
                return NotFound("Company cannot be found in CEIDG");
            }
            return Ok(company);
        }
    }
}
