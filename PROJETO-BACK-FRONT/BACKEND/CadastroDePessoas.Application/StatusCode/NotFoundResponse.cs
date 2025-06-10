using Microsoft.AspNetCore.Http;

namespace CadastroDePessoas.Application.StatusCode
{
    public class NotFoundResponse
    {
        public int StatusCode { get; set; } = StatusCodes.Status404NotFound;
        public string Message { get; set; } = "Recurso não encontrado.";

        public NotFoundResponse(string? message = null)
        {
            Message = message ?? Message;
        }
    }
}
