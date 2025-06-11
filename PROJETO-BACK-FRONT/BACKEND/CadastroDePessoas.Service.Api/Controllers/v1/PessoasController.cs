using CadastroDePessoas.Application.Dtos.Pessoas;
using CadastroDePessoas.Application.Interfaces.Pessoas;
using CadastroDePessoas.Application.StatusCode;
using CadastroDePessoas.Domain.Entities;
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
        [ProducesResponseType(typeof(SuccessResponse<GetPessoaDto[]>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UnauthorizedResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get()
        {
            var result = _pessoaAppService.GetAll() ?? Array.Empty<GetPessoaDto>();
            if (result == null)
                return Ok(new SuccessResponse<GetPessoaDto[]>(Array.Empty<GetPessoaDto>()));

            return Ok(new SuccessResponse<GetPessoaDto[]>(result.ToArray()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SuccessResponse<GetPessoaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get(Guid id)
        {
            var pessoa = _pessoaAppService.Get(id);
            if (pessoa == null)
                return NotFound(new NotFoundResponse());

            return Ok(new SuccessResponse<GetPessoaDto>(pessoa));
        }

        //[Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(SuccessResponse<GetPessoaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(InternalServerErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(InputPessoaDto inputPessoaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new BadRequestResponse("Dados inválidos."));

            var result = await _pessoaAppService.Add(inputPessoaDto);

            return Ok(new SuccessResponse<InputPessoaDto>(result));
        }

        [Authorize(Roles = "adm")]
        [HttpPut]
        [ProducesResponseType(typeof(SuccessResponse<GetPessoaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(UpdatePessoaDto updatePessoaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new BadRequestResponse("Dados inválidos."));

            var result = await _pessoaAppService.Update(updatePessoaDto);

            if (result == null)
                return NotFound(new NotFoundResponse("Pessoa não encontrada."));

            return Ok(new SuccessResponse<UpdatePessoaDto>(result));
        }

        [Authorize(Roles = "oper")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SuccessResponse<GetPessoaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _pessoaAppService.Delete(id);
            if (result == Guid.Empty)
                return NotFound(new NotFoundResponse("Pessoa não encontrada."));

            return Ok(new SuccessResponse<string>("Pessoa excluída com sucesso."));
        }
    }
}
