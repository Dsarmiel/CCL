// <copyright file="ProductNotFoundException.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>
namespace CCL.Domain.Exceptions
{
    /// <summary>
    /// Excepción que se lanza cuando no se encuentra un producto específico.
    /// Hereda de <see cref="ApplicationException"/>.
    /// </summary>
    public class ProductNotFoundException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductNotFoundException"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="ProductNotFoundException"/>.
        /// </summary>
        public ProductNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductNotFoundException"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="ProductNotFoundException"/> con un mensaje de error específico.
        /// </summary>
        /// <param name="message">El mensaje que describe el error.</param>
        public ProductNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductNotFoundException"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="ProductNotFoundException"/> con un mensaje de error específico y una referencia a la excepción interna que es la causa de esta excepción.
        /// </summary>
        /// <param name="message">El mensaje de error que explica la razón de la excepción.</param>
        /// <param name="innerException">La excepción que causó la excepción actual.</param>
        public ProductNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Obtiene o establece el ID del producto que no se encontró.
        /// </summary>
        /// <value>El ID del producto no encontrado. Puede ser nulo si el ID no está disponible.</value>
        public int? ProductId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductNotFoundException"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="ProductNotFoundException"/> con un mensaje de error específico y el ID del producto que no se encontró.
        /// </summary>
        /// <param name="message">El mensaje que describe el error.</param>
        /// <param name="productId">El ID del producto que no se encontró.</param>
        public ProductNotFoundException(string message, int productId)
            : base(message)
        {
            ProductId = productId;
        }
    }
}
