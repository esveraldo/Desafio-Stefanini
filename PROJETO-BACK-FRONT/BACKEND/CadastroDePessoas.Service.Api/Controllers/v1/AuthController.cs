using CadastroDePessoas.Application.Dtos.Usuarios;
using CadastroDePessoas.Application.Interfaces.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDePessoas.Service.Api.Controllers.v1
{
    [Route("api/[controller]")]                                                                                                                                                                                                  
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAppService? _authAppService;

        public AuthController(IAuthAppService? authAppService)
        {
            _authAppService = authAppService;
        }
        
        [Route("login")]
        [HttpPost]
        [ProducesResponseType(typeof(LoginResponseDto), 200)]
        public IActionResult Login([FromBody] LoginRequestDto dto)
        {
            return StatusCode(200, _authAppService?.Login(dto));
        }
    }
}
