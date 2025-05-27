using CadastroDePessoas.Domain.Entities;
using FluentValidation;

namespace CadastroDePessoas.Domain.Validations
{
    public class PessoaV2Validattion : AbstractValidator<PessoaV2>
    {
        public PessoaV2Validattion()
        {
            RuleFor(e => e.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id é obrigatório");

            RuleFor(x => x.Endereco)
            .NotEmpty().WithMessage("Endereço é obrigatório na versão 2.");
        }
    }
}
