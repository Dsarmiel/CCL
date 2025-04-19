// <copyright file="LoginValidations.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>

namespace CCL.Application.Validations
{
    using CCL.Application.DTOs;

    /// <summary>
    /// Proporciona métodos para validar las credenciales de inicio de sesión de un usuario.
    /// </summary>
    public static class LoginValidations
    {
        /// <summary>
        /// Valida las credenciales proporcionadas por el usuario.
        /// </summary>
        /// <param name="login">El objeto <see cref="LoginDTO"/> que contiene el nombre de usuario y la contraseña.</param>
        /// <param name="message">Un mensaje descriptivo si las credenciales no son válidas.</param>
        /// <returns>
        /// <c>true</c> si las credenciales son válidas; de lo contrario, <c>false</c>.
        /// </returns>
        public static bool IsCredentialsValid(LoginDTO login, out string message)
        {
            message = string.Empty;

            if (login == null)
            {
                message = "Los datos de login no pueden ser nulos.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(login.Username))
            {
                message = "El nombre de usuario es obligatorio.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(login.Password))
            {
                message = "La contraseña es obligatoria.";
                return false;
            }

            if (!login.Username.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                message = "Usuario no autorizado.";
                return false;
            }

            if (login.Password != "ab123")
            {
                message = "Contraseña incorrecta.";
                return false;
            }

            return true;
        }
    }
}
