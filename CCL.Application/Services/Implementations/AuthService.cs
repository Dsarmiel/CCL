// <copyright file="AuthService.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>
namespace CCL.Application.Services.Implementations
{
    using CCL.Application.DTOs.Auth;
    using CCL.Application.Services.Interfaces;
    using CCL.Application.Validations;
    using CCL.Shared.Response;

    /// <summary>
    /// Servicio encargado de gestionar la autenticación de usuarios.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly ITokenService tokenService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="AuthService"/>.
        /// </summary>
        /// <param name="tokenService">Servicio utilizado para generar tokens de acceso.</param>
        public AuthService(ITokenService tokenService) 
        {
            this.tokenService = tokenService;
        }

        /// <summary>
        /// Inicia sesión de un usuario y genera un token si las credenciales son válidas.
        /// </summary>
        /// <param name="login">Objeto con los datos de acceso del usuario.</param>
        /// <returns>
        /// Una tarea que retorna un <see cref="ApiResponse{T}"/> con el token generado si las credenciales son correctas.
        /// </returns>
        public ApiResponse<string> Login(LoginDTO login)
        {
            var response = new ApiResponse<string>();
            try
            {
                if (!LoginValidations.IsCredentialsValid(login, out var validationMessage))
                {
                    response.Message = validationMessage;
                    return response;
                }

                string token = this.tokenService.CreateToken();
                return new ApiResponse<string>
                {
                    Success = true,
                    Message = "Token generado exitosamente.",
                    Data = token,
                };
            }
            catch (Exception ex)
            {
                response.Message = "Ocurrió un error inesperado durante el login.";
                response.Message += $" Detalles: {ex.Message}";
                return response;
            }
        }
    }
}
