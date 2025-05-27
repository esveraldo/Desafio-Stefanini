namespace CadastroDePessoas.Application.Dtos.Pessoas
{
    public class UpdatePessoaDto
    {
        public Guid Id { get; set; }    
        public string? Nome { get; set; }
        public string? Sexo { get; set; }
        public string? Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string? Naturalidade { get; set; }
        public string? Nacionalidade { get; set; }
        public long Cpf { get; set; }
    }
}
