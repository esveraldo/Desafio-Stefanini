using CadastroDePessoas.Domain.Entities;
using CadastroDePessoas.Domain.Interfaces.Security;
using CadastroDePessoas.Infraestructure.Security.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CadastroDePessoas.Infraestructure.Security.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenSettings? _tokenSettings;

        public TokenService(IOptions<TokenSettings> tokenSettings)
        {
            _tokenSettings = tokenSettings.Value;
        }

        public string CreateToken(UsuarioAuth userAuth)
        {
            var teste = _tokenSettings?.SecretKey;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, JsonConvert.SerializeObject(userAuth)),
                new Claim(ClaimTypes.Role, userAuth.Role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings?.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenSettings?.Issuer,
                audience: _tokenSettings?.Audience,
                claims: claims, //informações de identificação do usuário
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_tokenSettings?.ExpirationInMinutes)),
                signingCredentials: credentials //assinatura do token
                );

            //retornando o token
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(jwtSecurityToken);
        }
    }
}
