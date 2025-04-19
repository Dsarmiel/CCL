// <copyright file="LoginDTO.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>

namespace CCL.Application.DTOs.Auth
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Objeto de transferencia de datos para el inicio de sesión del usuario.
    /// Contiene el nombre de usuario y la contraseña.
    /// </summary>
    public class LoginDTO
    {
        /// <summary>
        /// Gets or sets obtiene o establece el nombre de usuario.
        /// Este campo es obligatorio.
        /// </summary>
        [Required]
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets obtiene o establece la contraseña del usuario.
        /// Este campo es obligatorio.
        /// </summary>
        [Required]
        public string? Password { get; set; }
    }
}
