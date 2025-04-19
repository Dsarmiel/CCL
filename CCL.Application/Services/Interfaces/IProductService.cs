// <copyright file="IProductService.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>

namespace CCL.Application.Services.Interfaces
{
    using CCL.Application.DTOs.Product;

    /// <summary>
    /// Define la interfaz para el servicio de gestión de productos.
    /// Proporciona métodos para realizar operaciones relacionadas con los productos.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Obtiene asíncronamente una lista de todos los productos.
        /// </summary>
        /// <returns>Una tarea que representa la operación asíncrona.
        /// El resultado de la tarea contiene una lista de <see cref="ProductDTO"/>.</returns>
        Task<List<ProductDTO>> GetAllAsync();

        /// <summary>
        /// Actualiza asíncronamente la información de un producto existente.
        /// </summary>
        /// <param name="updateProductDTO">Un objeto <see cref="UpdateProductDTO"/>
        /// que contiene la información actualizada del producto.</param>
        /// <returns>Una tarea que representa la operación asíncrona.
        /// El resultado de la tarea contiene el <see cref="ProductDTO"/> actualizado.</returns>
        Task<ProductDTO> UpdateAsync(UpdateProductDTO updateProductDTO);
    }
}