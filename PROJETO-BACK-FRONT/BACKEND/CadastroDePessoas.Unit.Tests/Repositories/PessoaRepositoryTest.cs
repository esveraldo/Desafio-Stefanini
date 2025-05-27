using CadastroDePessoas.Domain.Entities;
using CadastroDePessoas.Domain.Interfaces.Repositories;
using FluentAssertions;
using Moq;

namespace CadastroDePessoas.Unit.Tests.Repositories
{
    public class PessoaRepositoryTest
    {
        private readonly Mock<IPessoaRepository> _pessoaRepositoryMock;
        private readonly Pessoa _pessoa;

        public PessoaRepositoryTest()
        {
            _pessoaRepositoryMock = new Mock<IPessoaRepository>();

            _pessoa = new Pessoa
            {
                Id = Guid.NewGuid(),
                Nome = "Anna Luiza Carvalho",
                Sexo = "Feminino",
                Email = "anna@email.com",
                DataDeNascimento = new DateTime(1990, 5, 23),
                Naturalidade = "Rio de Janeiro",
                Nacionalidade = "Brasileira",
                Cpf = 12345678900
            };

            _pessoaRepositoryMock.Setup(repo => repo.GetById(_pessoa.Id)).Returns(_pessoa);
            _pessoaRepositoryMock.Setup(repo => repo.GetAll()).Returns(new List<Pessoa> { _pessoa });
            _pessoaRepositoryMock.Setup(repo => repo.Create(It.IsAny<Pessoa>())).Verifiable();
            _pessoaRepositoryMock.Setup(repo => repo.Update(It.IsAny<Pessoa>())).Verifiable();
            _pessoaRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Pessoa>())).Verifiable();
        }

        [Fact]
        public void Create_DeveChamarMetodoCreate()
        {
            _pessoaRepositoryMock.Object.Create(_pessoa);
            _pessoaRepositoryMock.Verify(repo => repo.Create(_pessoa), Times.Once);
        }

        [Fact]
        public void GetById_DeveRetornarPessoaCorreta()
        {
            var result = _pessoaRepositoryMock.Object.GetById(_pessoa.Id);

            result.Should().NotBeNull();
            result.Nome.Should().Be(_pessoa.Nome);
            result.Email.Should().Be(_pessoa.Email);
        }

        [Fact]
        public void GetAll_DeveRetornarListaComPessoas()
        {
            var result = _pessoaRepositoryMock.Object.GetAll();

            result.Should().NotBeNull();
            result.Should().ContainSingle();
        }

        [Fact]
        public void Update_DeveChamarMetodoUpdate()
        {
            _pessoa.Nome = "Anna Atualizada";
            _pessoaRepositoryMock.Object.Update(_pessoa);

            _pessoaRepositoryMock.Verify(repo => repo.Update(_pessoa), Times.Once);
        }

        [Fact]
        public void Delete_DeveChamarMetodoDelete()
        {
            _pessoaRepositoryMock.Object.Delete(_pessoa);

            _pessoaRepositoryMock.Verify(repo => repo.Delete(_pessoa), Times.Once);
        }
    }
}
