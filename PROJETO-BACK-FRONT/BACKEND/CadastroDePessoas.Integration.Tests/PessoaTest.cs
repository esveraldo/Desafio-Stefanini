using CadastroDePessoas.Application.Dtos.Pessoas;
using CadastroDePessoas.Integration.Tests.Helpers;
using FluentAssertions;
using System.Net;

namespace CadastroDePessoas.Integration.Tests
{
    public class PessoaTest
    {
        private readonly TestHelper _testHelper;

        public PessoaTest()
        {
            _testHelper = new TestHelper();
        }

        [Fact]
        public async Task Test_Post_Email_Returns_Created()
        {
            var email = new InputPessoaDto
            {
                Nome = "Anna Luiza",
                Sexo = "Feminino",
                Email = "anna@email.com",
                DataDeNascimento = DateTime.Now,
                Naturalidade = "Rio de Janeiro",
                Nacionalidade = "Brasileira",
                Cpf = 123,
        };

            var content = _testHelper.CreateContent(email);
            var result = await _testHelper.CreateClient().PostAsync("/api/v1.0/pessoas", content);

            result.StatusCode
                .Should()
                    .Be(HttpStatusCode.Created);
        }
    }
}