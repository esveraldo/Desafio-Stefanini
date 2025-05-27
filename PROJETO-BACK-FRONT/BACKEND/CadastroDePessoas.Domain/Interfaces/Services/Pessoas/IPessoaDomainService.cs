using CadastroDePessoas.Domain.Entities;

namespace CadastroDePessoas.Domain.Interfaces.Services.Pessoas
{
    public interface IPessoaDomainService : IDisposable
    {
        void NovaPessoa(Pessoa pessoa);
        void AtualizarPessoa(Pessoa pessoa);
        void DeletarPessoa(Pessoa pessoa);
        List<Pessoa> TodasPessoas();
        Pessoa PegarPessoa(Guid id);
        Pessoa PegarPeloCpf(long cpf);
    }
}
