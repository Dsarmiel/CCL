// <copyright file="ITokenService.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>

// <summary>
// Define la interfaz para el servicio de generación de tokens JWT.
// </summary>
namespace CCL.Application.Services.Interfaces
{
    /// <summary>
    /// Proporciona la funcionalidad para generar tokens JWT.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Crea y retorna un token JWT como cadena de texto.
        /// </summary>
        /// <returns>Una cadena que representa el token JWT generado.</returns>
        string CreateToken();
    }
}
