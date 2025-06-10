using Microsoft.AspNetCore.Http;

namespace CadastroDePessoas.Application.StatusCode
{
    public class UnauthorizedResponse
    {
        public int StatusCode { get; set; } = StatusCodes.Status401Unauthorized;
        public string Message { get; set; } = "Não autorizado.";

        public UnauthorizedResponse(string? message = null)
        {
            Message = message ?? Message;
        }
    }
}
