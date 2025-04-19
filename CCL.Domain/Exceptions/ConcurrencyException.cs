// <copyright file="ConcurrencyException.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>
namespace CCL.Domain.Exceptions
{
    /// <summary>
    /// Excepción que se lanza cuando ocurre un error de concurrencia,
    /// indicando que los datos han sido modificados por otro proceso o usuario.
    /// Hereda de <see cref="ApplicationException"/>.
    /// </summary>
    public class ConcurrencyException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConcurrencyException"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="ConcurrencyException"/>.
        /// </summary>
        public ConcurrencyException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConcurrencyException"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="ConcurrencyException"/> con un mensaje de error específico.
        /// </summary>
        /// <param name="message">El mensaje que describe el error de concurrencia.</param>
        public ConcurrencyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConcurrencyException"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="ConcurrencyException"/> con un mensaje de error específico y una referencia a la excepción interna que es la causa de esta excepción.
        /// </summary>
        /// <param name="message">El mensaje de error que explica la razón de la excepción de concurrencia.</param>
        /// <param name="innerException">La excepción que causó la excepción actual.</param>
        public ConcurrencyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}