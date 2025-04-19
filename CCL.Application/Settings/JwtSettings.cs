// <copyright file="JwtSettings.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>
// <summary>
// Contiene la clase de configuración para los parámetros del token JWT.
// </summary>
namespace CCL.Application.Settings
{
    /// <summary>
    /// Representa la configuración necesaria para la generación y validación de tokens JWT.
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Gets or sets obtiene o establece el emisor del token JWT.
        /// </summary>
        public string? Issuer { get; set; }

        /// <summary>
        /// Gets or sets obtiene o establece el público objetivo del token JWT.
        /// </summary>
        public string? Audience { get; set; }

        /// <summary>
        /// Gets or sets obtiene o establece la clave secreta utilizada para firmar el token JWT.
        /// </summary>
        public string? SigningKey { get; set; }

        /// <summary>
        /// Gets or sets obtiene o establece el tiempo de expiración del token JWT en minutos.
        /// </summary>
        public int ExpirationDays { get; set; } = 7;
    }
}
