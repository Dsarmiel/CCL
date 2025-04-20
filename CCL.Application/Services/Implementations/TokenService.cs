// <copyright file="TokenService.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>
namespace CCL.Application.Services.Implementations
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;
    using CCL.Application.Services.Interfaces;
    using CCL.Application.Settings;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// Servicio responsable de generar tokens JWT utilizando los parámetros configurados.
    /// </summary>
    public class TokenService : ITokenService
    {
        private readonly JwtSettings jwtSettings;
        private readonly SymmetricSecurityKey key;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenService"/> class.
        /// </summary>
        /// <param name="jwtOptions">Options that contain the JWT configuration.</param>
        public TokenService(IOptions<JwtSettings> jwtOptions)
        {
            this.jwtSettings = jwtOptions.Value
                ?? throw new ArgumentNullException(nameof(jwtOptions));

            if (string.IsNullOrWhiteSpace(this.jwtSettings.SigningKey))
            {
                throw new ArgumentException("SigningKey must be provided in JwtSettings.");
            }

            this.key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.jwtSettings.SigningKey));
        }

        /// <summary>
        /// Crea y retorna un token JWT basado en los parámetros configurados.
        /// </summary>
        /// <returns>Una cadena que representa el token JWT generado.</returns>
        public string CreateToken()
        {
            var creds = new SigningCredentials(this.key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddDays(this.jwtSettings.ExpirationDays),
                SigningCredentials = creds,
                Issuer = this.jwtSettings.Issuer,
                Audience = this.jwtSettings.Audience,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
