using CadastroDePessoas.Domain.Entities;
using FluentAssertions;

namespace CadastroDePessoas.Unit.Tests.Entities
{
    public class PessoaTest
    {
        [Fact]
        public void ValidarIdTest()
        {
            var pessoa = new Pessoa
            {
                Id = Guid.Empty
            };

            pessoa.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Id é obrigatório"))
                .Should()
                .NotBeNull();
        }
    }
}
