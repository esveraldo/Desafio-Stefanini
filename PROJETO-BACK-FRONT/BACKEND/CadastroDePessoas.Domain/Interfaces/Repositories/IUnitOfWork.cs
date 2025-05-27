namespace CadastroDePessoas.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void SaveChanges();

        IPessoaRepository pessoaRepository { get; }
        IUsuarioRepository usuarioRepository { get; }
        IAuthRepository authRepository { get; }
    }
}
