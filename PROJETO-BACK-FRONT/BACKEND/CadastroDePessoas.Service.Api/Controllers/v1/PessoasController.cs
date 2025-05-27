using CadastroDePessoas.Application.Dtos.Pessoas;
using CadastroDePessoas.Application.Interfaces.Pessoas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDePessoas.Service.Api.Controllers.v1
{
    [ApiVersion("1.0")]
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

        [HttpGet]
        [ProducesResponseType(typeof(GetPessoaDto), 201)]
        public async Task<ActionResult> Get()
        {
            return StatusCode(200, _pessoaAppService.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetPessoaDto), 201)]
        public async Task<ActionResult> Get(Guid id)
        {
            return StatusCode(200, _pessoaAppService.Get(id));
        }

        //[Authorize]
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

        [Authorize]
        [HttpPut]
        [ProducesResponseType(typeof(UpdatePessoaDto), 200)]
        public async Task<IActionResult> Put(UpdatePessoaDto updatePessoaDto)
        {
            var result = await _pessoaAppService.Update(updatePessoaDto);
            return StatusCode(200, result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(GetPessoaDto), 201)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = _pessoaAppService.Delete(id);
            return StatusCode(200, result);
        }
    }
}
