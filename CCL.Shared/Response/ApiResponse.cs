// <copyright file="ApiResponse.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>

namespace CCL.Shared.Response
{
    using System.Collections.Generic;

    /// <summary>
    /// Representa una respuesta estándar de la API.
    /// Incluye información sobre el estado de la operación, un mensaje,
    /// datos genéricos y una lista de errores en caso de que existan.
    /// </summary>
    /// <typeparam name="T">Tipo de dato que se desea devolver en la respuesta.</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether obtiene o establece un valor que indica si la operación fue exitosa.
        /// </summary>
        public bool Success { get; set; } = false;

        /// <summary>
        /// Gets or sets obtiene o establece el mensaje descriptivo de la respuesta.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets obtiene o establece los datos retornados por la operación.
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Gets or sets obtiene o establece una lista de errores si la operación no fue exitosa.
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();
    }
}
