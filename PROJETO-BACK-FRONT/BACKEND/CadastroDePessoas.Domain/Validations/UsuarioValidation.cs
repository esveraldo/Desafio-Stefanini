using CadastroDePessoas.Domain.Entities;
using FluentValidation;

namespace CadastroDePessoas.Domain.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(e => e.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id é obrigatório");
        }
    }
}
