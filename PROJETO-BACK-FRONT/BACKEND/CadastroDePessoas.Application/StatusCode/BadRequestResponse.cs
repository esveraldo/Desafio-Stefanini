using Microsoft.AspNetCore.Http;

namespace CadastroDePessoas.Application.StatusCode
{
    public class BadRequestResponse
    {
        public int StatusCode { get; set; } = StatusCodes.Status400BadRequest;
        public string Message { get; set; } = "Erro de validação.";
        public List<string>? Errors { get; set; }

        public BadRequestResponse(string message, List<string>? errors = null)
        {
            Message = message;
            Errors = errors;
        }
    }
}