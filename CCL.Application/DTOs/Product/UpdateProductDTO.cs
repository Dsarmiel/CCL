// <copyright file="UpdateProductDTO.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>

namespace CCL.Application.DTOs.Product
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Data Transfer Object (DTO) para actualizar la cantidad de un producto.
    /// </summary>
    public class UpdateProductDTO
    {
        /// <summary>
        /// Gets or sets obtiene o establece el ID del producto que se va a actualizar.
        /// Este campo es requerido.
        /// </summary>
        [Required]
        required public int Id { get; set; }

        /// <summary>
        /// Gets or sets obtiene o establece la nueva cantidad para el producto.
        /// Este campo es requerido.
        /// </summary>
        [Required]
        required public int Quantity { get; set; }
    }
}