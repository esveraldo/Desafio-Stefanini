using AutoMapper;
using CadastroDePessoas.Application.Dtos.Pessoas;
using CadastroDePessoas.Application.Interfaces.Pessoas;
using CadastroDePessoas.Application.Mappings;
using CadastroDePessoas.Domain.Entities;
using CadastroDePessoas.Domain.Interfaces.Services.Pessoas;
using FluentValidation;

namespace CadastroDePessoas.Application.Services.Pessoas
{
    public class PessoaAppService : IPessoaAppService
    {
        private readonly IMapper _mapper;
        private readonly IPessoaDomainService _pessoasDomainService;

        public PessoaAppService(IMapper mapper, IPessoaDomainService pessoasDomainService)
        {
            _mapper = mapper;
            _pessoasDomainService = pessoasDomainService;
        }

        public async Task<InputPessoaDto> Add(InputPessoaDto inputPessoaDto)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var pessoa = mapper.Map<Pessoa>(inputPessoaDto);

            var validate = pessoa.Validate;
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            _pessoasDomainService.NovaPessoa(pessoa);

            return inputPessoaDto;
        }

        public async Task<UpdatePessoaDto> Update(UpdatePessoaDto updatePessoaDto)
        {
            var pessoa = _pessoasDomainService.PegarPessoa(updatePessoaDto.Id);
            pessoa.Nome = updatePessoaDto.Nome;
            pessoa.Sexo = updatePessoaDto.Sexo;
            pessoa.Email = updatePessoaDto.Email;
            pessoa.DataDeNascimento = updatePessoaDto.DataDeNascimento;
            pessoa.Naturalidade = updatePessoaDto.Naturalidade;
            pessoa.Nacionalidade = updatePessoaDto.Nacionalidade;
            pessoa.Cpf = updatePessoaDto.Cpf;
            pessoa.DataDeAtualizacao = DateTime.Now;
        
            _pessoasDomainService.AtualizarPessoa(pessoa);

            return updatePessoaDto;
        }

        public async Task<Guid> Delete(Guid id)
        {
            var pessoa = _pessoasDomainService.PegarPessoa(id);
            _pessoasDomainService.DeletarPessoa(pessoa);

            return id;
        }

        public GetPessoaDto Get(Guid id)
        {
            return _mapper.Map<GetPessoaDto>(_pessoasDomainService.PegarPessoa(id));
        }

        public IEnumerable<GetPessoaDto> GetAll()
        {
            return _mapper.Map<IEnumerable<GetPessoaDto>>(_pessoasDomainService.TodasPessoas());
        }
    }
}
