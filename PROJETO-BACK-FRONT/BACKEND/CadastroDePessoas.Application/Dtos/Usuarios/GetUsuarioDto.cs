﻿namespace CadastroDePessoas.Application.Dtos.Usuarios
{
    public class GetUsuarioDto
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Role { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
