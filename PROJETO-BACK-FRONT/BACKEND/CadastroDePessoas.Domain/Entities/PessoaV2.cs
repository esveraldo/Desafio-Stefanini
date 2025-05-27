using CadastroDePessoas.Domain.ValueObject;

namespace CadastroDePessoas.Domain.Entities
{
    public class PessoaV2 : Pessoa
    {
        public Endereco? Endereco { get; set; }

        //public ValidationResult Validate => new PessoaV2Validation().Validate(this);
    }
}
