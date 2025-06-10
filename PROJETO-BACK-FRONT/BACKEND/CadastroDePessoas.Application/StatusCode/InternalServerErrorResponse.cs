using Microsoft.AspNetCore.Http;

namespace CadastroDePessoas.Application.StatusCode
{
    public class InternalServerErrorResponse
    {
        public int StatusCode { get; set; } = StatusCodes.Status500InternalServerError;
        public string Message { get; set; } = "Erro interno no servidor.";

        public InternalServerErrorResponse(string? message = null)
        {
            Message = message ?? Message;
        }
    }
}
