// <copyright file="DatabaseOperationException.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>
namespace CCL.Domain.Exceptions
{
    /// <summary>
    /// Excepción que se lanza cuando ocurre un error durante una operación de base de datos.
    /// Hereda de <see cref="ApplicationException"/>.
    /// </summary>
    public class DatabaseOperationException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseOperationException"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="DatabaseOperationException"/>.
        /// </summary>
        public DatabaseOperationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseOperationException"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="DatabaseOperationException"/> con un mensaje de error específico.
        /// </summary>
        /// <param name="message">El mensaje que describe el error de la operación de base de datos.</param>
        public DatabaseOperationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseOperationException"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="DatabaseOperationException"/> con un mensaje de error específico y una referencia a la excepción interna que es la causa de esta excepción.
        /// </summary>
        /// <param name="message">El mensaje de error que explica la razón de la excepción de la operación de base de datos.</param>
        /// <param name="innerException">La excepción que causó la excepción actual.</param>
        public DatabaseOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}