using CadastroDePessoas.Domain.Core;
using CadastroDePessoas.Domain.Validations;
using FluentValidation.Results;

namespace CadastroDePessoas.Domain.Entities
{
    public class Usuario : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Role { get; set; }
        public DateTime CriadoEm { get; set; }

        public ValidationResult Validate => new UsuarioValidation().Validate(this);
    }
}
