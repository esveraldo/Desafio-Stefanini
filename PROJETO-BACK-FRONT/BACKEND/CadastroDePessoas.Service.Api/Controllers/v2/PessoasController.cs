using CadastroDePessoas.Application.Dtos.Pessoas;
using CadastroDePessoas.Application.Interfaces.Pessoas;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDePessoas.Service.Api.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaAppService _pessoaAppService;

        public PessoasController(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(InputPessoaDto), 201)]
        public async Task<ActionResult> Post(InputPessoaDto inputPessoaDto)
        {
            var result = await _pessoaAppService.Add(inputPessoaDto);
            return StatusCode(201, new
            {
                message = result,
                inputPessoaDto
            });
        }
    }
}
