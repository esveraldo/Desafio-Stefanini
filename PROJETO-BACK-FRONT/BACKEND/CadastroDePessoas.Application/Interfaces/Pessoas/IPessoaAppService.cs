using CadastroDePessoas.Application.Dtos.Pessoas;

namespace CadastroDePessoas.Application.Interfaces.Pessoas
{
    public interface IPessoaAppService
    {
        Task<InputPessoaDto> Add(InputPessoaDto inputPessoaDto);
        Task<UpdatePessoaDto> Update(UpdatePessoaDto updatePessoaDto);
        Task<Guid> Delete(Guid id);
        IEnumerable<GetPessoaDto> GetAll();
        GetPessoaDto Get(Guid id);
    }
}
