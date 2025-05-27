using CadastroDePessoas.Domain.Entities;

namespace CadastroDePessoas.Infraestructure.Data.Contexts
{
    public class DataSeeder
    {
        private readonly DataContext _dataContext;

        public DataSeeder(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Seed()
        {
            _dataContext.Database.EnsureCreated();

            if (_dataContext.Usuarios.Any()) return;


            _dataContext.Usuarios.AddRange(
                new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Administrador",
                    Email = "adm@email.com",
                    Senha = "Logar@123",
                    Role = "adm",
                    CriadoEm = DateTime.Now

                },
                new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Operador",
                    Email = "oper@email.com",
                    Senha = "Logar@123",
                    Role = "oper",
                    CriadoEm = DateTime.Now

                }
            );

            _dataContext.SaveChanges();
        }
    }
}
