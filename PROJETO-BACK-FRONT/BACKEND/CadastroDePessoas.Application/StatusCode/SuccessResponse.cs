using Microsoft.AspNetCore.Http;

namespace CadastroDePessoas.Application.StatusCode
{
    public class SuccessResponse<T>
    {
        public int StatusCode { get; set; } = StatusCodes.Status200OK;
        public string Message { get; set; }
        public T Data { get; set; }

        public SuccessResponse(T data, string? message = null)
        {
            if (data == null)
                Data = default!;
            else
                Data = data;

            Message = message ?? "Requisição bem-sucedida.";
        }
    }
}
