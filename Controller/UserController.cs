using Microsoft.AspNetCore.Mvc;
using WholeSaler.DTO;
using WholeSaler.IService;

namespace WholeSaler.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserAuthService _userService;

        public UserController(IUserAuthService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterDTO registerDTO)
        {
            _userService.RegisterUser(registerDTO);
            return Ok($"Hello {registerDTO.Email}");
        }
        [HttpPost("login")]
        public ActionResult Authorization([FromBody] LoginDTO loginDTO)
        {
            string token = _userService.AuthByJwt(loginDTO);
            return Ok(token);
        }
    }
}
