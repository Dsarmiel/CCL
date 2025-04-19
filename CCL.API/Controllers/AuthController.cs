// <copyright file="AuthController.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>

namespace CCL.API.Controllers
{
    using CCL.Application.DTOs;
    using CCL.Application.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controlador responsable de las operaciones de autenticación.
    /// </summary>
    [Route("auth/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="AuthController"/>.
        /// </summary>
        /// <param name="authService">Servicio de autenticación de usuarios.</param>
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        /// <summary>
        /// Realiza el inicio de sesión de un usuario con las credenciales proporcionadas.
        /// </summary>
        /// <param name="login">Datos de acceso del usuario.</param>
        /// <returns>
        /// Una respuesta HTTP con el resultado de la operación de inicio de sesión.
        /// </returns>
        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            var result = this.authService.Login(login);
            if (result.Success)
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }
    }
}
