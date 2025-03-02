using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GestionTareas.Api.Utility
{
    public class Custom
    {
        private readonly IConfiguration _configuration;
        public Custom(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string encriptarSHA256(string texto)
        {
            try
            {
                Log.Information("Start method: Custom-encriptarSHA256");

                using (SHA256 sha256hash = SHA256.Create())
                {
                    //Computar el hash
                    byte[] bytes = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(texto));

                    //Convertir array de bytes a string
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }

                    return builder.ToString();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return ex.ToString();
            }

        }

        public string GenerarJWT(double clienteId, string clienteCodigo, string clienteUsuario)
        {
            try
            {
                Log.Information("Start method: Custom-GenerarJWT");

                //Crear la info del usuario para el token

                var userClaims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, clienteId.ToString()),
                new Claim(ClaimTypes.SerialNumber, clienteCodigo),
                new Claim(ClaimTypes.Name, clienteUsuario)
            };

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!));
                var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

                //Detalle del Token
                var JWTConfig = new JwtSecurityToken(
                    claims: userClaims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: credential
                    );

                return new JwtSecurityTokenHandler().WriteToken(JWTConfig);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return ex.ToString();
            }

        }

        public string DecodeJWT(JwtSecurityToken token)
        {
            try
            {
                Log.Information("Start method: Custom-DecodeJWT");

                var keyId = token.Header.Kid;
                var audience = token.Audiences.ToList();
                var claims = token.Claims.Select(claim => (claim.Type, claim.Value)).ToList();

                return "";

            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return ex.ToString();
            }
        }
    }
}
