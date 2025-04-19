// <copyright file="IProductRepository.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>

namespace CCL.Domain.Repositories
{
    using CCL.Domain.Entities;

    /// <summary>
    /// Define las operaciones de acceso a datos para la entidad <see cref="Product"/>.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Obtiene todos los productos disponibles.
        /// </summary>
        /// <returns>Una lista de productos.</returns>
        Task<List<Product>> GetAllAsync();

        /// <summary>
        /// Actualiza la información de un producto existente.
        /// </summary>
        /// <param name="id">El ID del producto que se va a actualizar.</param>
        /// <param name="quantity">La nueva cantidad para el producto.</param>
        /// /// <returns>El producto actualizado.</returns>
        Task<Product> UpdateAsync(int id, int quantity);
    }
}
