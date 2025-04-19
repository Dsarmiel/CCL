// <copyright file="ProductDTO.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>

namespace CCL.Application.DTOs.Product
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Data Transfer Object (DTO) para representar la información básica de un producto.
    /// </summary>
    public class ProductDTO
    {
        /// <summary>
        /// Gets or sets obtiene o establece el ID del producto.
        /// Este campo es requerido.
        /// </summary>
        [Required]
        required public int Id { get; set; }

        /// <summary>
        /// Gets or sets obtiene o establece el nombre del producto.
        /// Este campo es requerido.
        /// </summary>
        [Required]
        required public string Name { get; set; }

        /// <summary>
        /// Gets or sets obtiene o establece la cantidad disponible del producto.
        /// Este campo es requerido.
        /// </summary>
        [Required]
        required public int Quantity { get; set; }
    }
}