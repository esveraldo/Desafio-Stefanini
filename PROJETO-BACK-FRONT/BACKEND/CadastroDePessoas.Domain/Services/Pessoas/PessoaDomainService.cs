using CadastroDePessoas.Domain.Entities;
using CadastroDePessoas.Domain.Exceptions;
using CadastroDePessoas.Domain.Interfaces.Repositories;
using CadastroDePessoas.Domain.Interfaces.Services.Pessoas;

namespace CadastroDePessoas.Domain.Services.Pessoas
{
    public class PessoaDomainService : IPessoaDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PessoaDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public Pessoa PegarPessoa(Guid id)
        {
            return _unitOfWork.pessoaRepository.GetById(id);
        }

        public List<Pessoa> TodasPessoas()
        {
            return _unitOfWork.pessoaRepository.GetAll().ToList();
        }

        public void NovaPessoa(Pessoa pessoa)
        {
            if(PegarPeloCpf(pessoa.Cpf) != null)
                throw new CpfAlreadyExistsException(pessoa.Cpf);

            _unitOfWork.pessoaRepository.Create(pessoa);
            _unitOfWork.SaveChanges();
        }

        public void AtualizarPessoa(Pessoa pessoa)
        {
            _unitOfWork.pessoaRepository.Update(pessoa);
            _unitOfWork.SaveChanges();
        }

        public void DeletarPessoa(Pessoa pessoa)
        {
            _unitOfWork.pessoaRepository.Delete(pessoa);
            _unitOfWork.SaveChanges();
        }

        public Pessoa PegarPeloCpf(long cpf)
        {
            return _unitOfWork?.pessoaRepository.Get(u => u.Cpf.Equals(cpf));
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
