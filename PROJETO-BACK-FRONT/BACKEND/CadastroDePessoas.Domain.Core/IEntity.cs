using FluentValidation.Results;

namespace CadastroDePessoas.Domain.Core
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
        ValidationResult Validate {  get; }
    }
}
