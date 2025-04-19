// <copyright file="IAuthService.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>

namespace CCL.Application.Services.Interfaces
{
    using CCL.Application.DTOs;
    using CCL.Shared.Response;

    /// <summary>
    /// Define los métodos relacionados con la autenticación de usuarios.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Inicia sesión de un usuario y genera un token de acceso.
        /// </summary>
        /// <param name="login">Los datos de inicio de sesión del usuario.</param>
        /// <returns>
        /// El resultado contiene un <see cref="ApiResponse{T}"/> con el token generado como cadena.
        /// </returns>
        ApiResponse<string> Login(LoginDTO login);
    }
}

