using CadastroDePessoas.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDePessoas.Domain.Validations
{
    public class PessoaValidation : AbstractValidator<Pessoa>
    {
        public PessoaValidation()
        {
            RuleFor(e => e.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id é obrigatório");
        }
    }
}
