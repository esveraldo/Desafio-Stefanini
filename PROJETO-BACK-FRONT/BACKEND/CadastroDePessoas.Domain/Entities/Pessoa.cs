using CadastroDePessoas.Domain.Core;
using CadastroDePessoas.Domain.Validations;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDePessoas.Domain.Entities
{
    public class Pessoa : IEntity<Guid>
    {
        public Pessoa()
        {
            DataDeCadastro = DateTime.Now;
            DataDeAtualizacao = DateTime.Now;
            Id = Guid.NewGuid();

        }
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Sexo { get; set; }
        public string? Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string? Naturalidade { get; set; }
        public string? Nacionalidade { get; set; }
        public DateTime DataDeCadastro { get; set; }
        public DateTime DataDeAtualizacao { get; set; }
        public long Cpf { get; set; }

        public ValidationResult Validate => new PessoaValidation().Validate(this);
    }
}
