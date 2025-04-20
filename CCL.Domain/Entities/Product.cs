// <copyright file="Product.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>

namespace CCL.Domain.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Representa un producto en el sistema.
    /// </summary>
    [Table("productos")]
    public class Product
    {
        /// <summary>
        /// Gets or sets obtiene o establece el identificador único del producto.
        /// </summary>
        [Column(name: "id")]
        required public int Id { get; set; }

        /// <summary>
        /// Gets or sets obtiene o establece el nombre del producto.
        /// </summary>
        [Column(name: "nombre")]
        required public string Name { get; set; }

        /// <summary>
        /// Gets or sets obtiene o establece la cantidad del producto disponible.
        /// </summary>
        [Column(name: "cantidad")]
        required public int Quantity { get; set; }
    }
}
